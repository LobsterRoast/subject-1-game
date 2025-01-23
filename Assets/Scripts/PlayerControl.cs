using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : Controllable {
    private GameObject instance;
    private FillMeter jetpack_fuel_meter_field = null;
    private DialogueController active_dialogue_controller;
    private Player player;


    public KeyCode create_instance;
    public KeyCode advance_dialogue;
    public int attack;
    public GameObject instance_prefab;
    public PlayerWeapon player_weapon;
    public bool in_dialogue;
    protected override FillMeter jetpack_fuel_meter_prop {
        get {
            if(jetpack_fuel_meter_field)
                return jetpack_fuel_meter_field;
            else {
                return (jetpack_fuel_meter_field = GameObject
                    .FindWithTag("JetpackFuelMeter")
                    .GetComponent<FillMeter>());
                }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        active_dialogue_controller = other.gameObject.GetComponent<DialogueController>();
    }
    void OnTriggerExit(Collider other) {
        if (active_dialogue_controller) {
            if(other.gameObject.GetComponent<DialogueController>() == active_dialogue_controller) {
                active_dialogue_controller.EndDialogue();
                active_dialogue_controller = null;
                in_dialogue = false;
            }
        }
    }
    public void AdvanceDialogue(int index) {
        active_dialogue_controller.Advance(index);
    }
    private void ToggleInstance() {
        if (instance)
            Destroy(instance);
        else {
            instance = Instantiate(instance_prefab, transform.position, transform.rotation);
            instance.transform.parent = null;
        }
    }

    private void ShootProjectile() {
            Vector3 mouse_pos = Input.mousePosition;
            mouse_pos.x -= Screen.width/2;
            mouse_pos.y -= Screen.height/2;
            player_weapon.Attack(mouse_pos.normalized, player);
    }
    
    protected override void PrefabSpecificInputs() {
        if (Keybinds.GetInputDown(bindings.toggle_instance) &&
            entity.CheckAccessory(Accessory.Instantiator))
            ToggleInstance();
        if (Keybinds.GetInputDown(bindings.attack)) {
            ShootProjectile();
        }
        if (Keybinds.GetInputDown(bindings.advance_or_start_dialogue) && active_dialogue_controller) {
            if (in_dialogue)
                in_dialogue = active_dialogue_controller.Advance();
            else {
                active_dialogue_controller.StartDialogue();
                in_dialogue = true;
            }
        }
        if (entity.CheckAccessory(Accessory.Gravity_Manipulator)) {
            float axis = 0;
            if (Keybinds.GetInput(bindings.increase_gravity))
                axis++;
            if (Keybinds.GetInput(bindings.decrease_gravity))
                axis--;
            global_info.ChangeGravity(axis*3f);
        }
    }
    protected override void ControllableStart() {
        player = GetComponent<Player>();
        walk_left = bindings.player_walk_left;
        walk_right = bindings.player_walk_right;
        jump = bindings.player_jump;
        jetpack = bindings.player_jetpack;
    }
}

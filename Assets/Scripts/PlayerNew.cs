using UnityEngine;

public class PlayerNew : ControllableEntityNew {
    
    public Accessory active_accessory;
    public static PlayerNew player;
    public Weapon weapon;
    public override EntityType entity_type => EntityType.Player;
    protected override void OnProjectileHit(Projectile projectile) {}
    protected override void OnDeath() {}
    protected override FillMeter jetpack_fuel_meter => null;
    private DialogueController active_dialogue_controller;
    public override void Awake() {
        base.Awake();
        player = this;
    }
    public override void Start() {
        base.Start();
    }
    public void OnTriggerEnter(Collider other)
    {
        active_dialogue_controller = other.gameObject.GetComponent<DialogueController>();
    }
    private void Attack() {
        // The entity shooting the weapon is passed to the Fire() function as this will determine the projectile's behavior
        weapon.Fire(this);
    }
    protected void EngageOrAdvanceDialogue() {
        active_dialogue_controller.Advance();
    }
    protected void ToggleMenu() { }
    protected void ToggleInstance() { }
    private void IncreaseGravity() { 
        gravity_system.ChangeGravity(0.5f);
    }
    private void DecreaseGravity() {
        gravity_system.ChangeGravity(-0.5f);
    }
    protected override void GetInputs() {
        if (Keybinds.GetInput(keybinds.player_walk_left))
            WalkLeft();
        if (Keybinds.GetInput(keybinds.player_walk_right))
            WalkRight();
        if (Keybinds.GetInputDown(keybinds.attack))
            Attack();
        if (Keybinds.GetInputDown(keybinds.open_menu))
            ToggleMenu();
        if (Keybinds.GetInputDown(keybinds.advance_or_start_dialogue))
            EngageOrAdvanceDialogue();
        if (Keybinds.GetInputDown(keybinds.player_jump)) {
            if (is_grounded)
                Jump();
            else if (can_double_jump) {
                Jump();
                can_double_jump = false;
            }
        }

        switch (active_accessory) {
            case Accessory.Jetpack:
                if (Keybinds.GetInput(keybinds.player_jetpack))
                    Jetpack();
                break;
            case Accessory.Instantiator:
                if (Keybinds.GetInputDown(keybinds.toggle_instance))
                    ToggleInstance();
                break;
            case Accessory.Gravity_Manipulator:
                if (Keybinds.GetInputDown(keybinds.increase_gravity))
                    IncreaseGravity();
                if (Keybinds.GetInputDown(keybinds.decrease_gravity))
                    DecreaseGravity();
                break;
        }
    }
}
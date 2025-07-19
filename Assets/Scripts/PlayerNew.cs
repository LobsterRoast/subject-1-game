using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class PlayerNew : ControllableEntityNew {
    public Weapon weapon;
    public override EntityType entity_type => EntityType.Player;
    protected override void OnProjectileHit(Projectile projectile) {}
    protected override void OnDeath() {}
    protected override FillMeter jetpack_fuel_meter => null;
    private void Attack() {
        // The entity shooting the weapon is passed to the Fire() function as this will determine the projectile's behavior
        weapon.Fire(this);
    }
    protected override void GetInputs() {
        if (Keybinds.GetInput(keybinds.player_walk_left))
            WalkLeft();
        if (Keybinds.GetInput(keybinds.player_walk_right))
            WalkRight();
        if (Keybinds.GetInput(keybinds.player_jetpack))
            Jetpack();
        if (Keybinds.GetInputDown(keybinds.toggle_instance))
            ToggleInstance();
        if (Keybinds.GetInputDown(keybinds.attack))
            Attack();
        if (Keybinds.GetInputDown(keybinds.open_menu))
            ToggleMenu();
        if (Keybinds.GetInputDown(keybinds.advance_or_start_dialogue))
            EngageOrAdvanceDialogue();
        if (Keybinds.GetInputDown(keybinds.increase_gravity))
            IncreaseGravity();
        if (Keybinds.GetInputDown(keybinds.decrease_gravity))
            DecreaseGravity();
        if (Keybinds.GetInputDown(keybinds.player_jump)) {
            if (is_grounded)
                Jump();
            else if (can_double_jump) {
                Jump();
                can_double_jump = false;
            }
        }
    }
}
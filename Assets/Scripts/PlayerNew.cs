using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class PlayerNew : ControllableEntityNew {
    public override EntityType entity_type => EntityType.Player;
    protected override void OnProjectileHit(Projectile projectile) {}
    protected override void OnDeath() {}
    protected override FillMeter jetpack_fuel_meter => null;
    protected override void GetInputs() {
        if (Keybinds.GetInput(keybinds.player_walk_left))
            WalkLeft();
        if (Keybinds.GetInput(keybinds.player_walk_right))
            WalkRight();
        if (Keybinds.GetInputDown(keybinds.player_jump))
            Jump();
    }
}
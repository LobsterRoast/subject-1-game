using UnityEngine;

public abstract class ControllableEntityNew : Entity {
    public override void Start() {
        base.Start();
    }
    public override void Update() {
        base.Update();
    }
    protected abstract FillMeter jetpack_fuel_meter { get; }
    private void GetInputs(Keybinds bindings) {

    }
}
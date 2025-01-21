using UnityEngine;
using UnityEngine.InputSystem;

public class InstanceControl : Controllable {
    private FillMeter jetpack_fuel_meter_field = null;
    protected override FillMeter jetpack_fuel_meter_prop {
        get {
            if(jetpack_fuel_meter_field)
                return jetpack_fuel_meter_field;
            else
                return (jetpack_fuel_meter_field = GameObject
                    .FindWithTag("InstanceJetpackFuelMeter")
                    .GetComponent<FillMeter>());
        }
    }
    protected override void ControllableStart() {
        walk_left = bindings.instance_walk_left;
        walk_right = bindings.instance_walk_right;
        jump = bindings.instance_jump;
        jetpack = bindings.instance_jetpack;   
    }

    protected override void PrefabSpecificInputs() {

    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "Keybinds", menuName = "Scriptable Objects/Keybinds")]
public class Keybinds : ScriptableObject
{
    [Header("Player Movement Bindings")]
    public KeyCode player_walk_left;
    public KeyCode player_walk_right;
    public KeyCode player_jump;
    [Header("Instance Movement Bindings")]
    public KeyCode instance_walk_left;
    public KeyCode instance_walk_right;
    public KeyCode instance_jump;
    [Header("Accessory Usage Bindings")]
    public KeyCode player_jetpack;
    public KeyCode instance_jetpack;
    public KeyCode toggle_instance;
    public KeyCode increase_gravity;
    public KeyCode decrease_gravity;
    [Header("Combat Bindings")]
    public KeyCode attack;
    [Header("Interaction Bindings")]
    public KeyCode advance_or_start_dialogue;
    public static bool GetInputDown(KeyCode key_code) {
        switch(key_code) {
            case KeyCode.WheelUp:
                return Input.GetAxis("Mouse ScrollWheel") > 0;
                break;
            case KeyCode.WheelDown:
                return Input.GetAxis("Mouse ScrollWheel") < 0;
                break;
            default:
                return Input.GetKeyDown(key_code);
                break;
        }
    }
    public static bool GetInput(KeyCode key_code) {
        switch(key_code) {
            case KeyCode.WheelUp:
                return Input.GetAxis("Mouse ScrollWheel") > 0;
                break;
            case KeyCode.WheelDown:
                return Input.GetAxis("Mouse ScrollWheel") < 0;
                break;
            default:
                return Input.GetKey(key_code);
                break;
        }
    }
}


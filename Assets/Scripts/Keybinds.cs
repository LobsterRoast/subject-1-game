using UnityEngine;

[CreateAssetMenu(fileName = "Keybinds", menuName = "Scriptable Objects/Keybinds")]
public class Keybinds : ScriptableObject
{
    [Header("Player Movement Bindings")]
    public KeyCode player_walk_left;
    public KeyCode player_walk_right;
    public KeyCode player_jump;
    public KeyCode player_jetpack;
    [Header("Instance Movement Bindings")]
    public KeyCode instance_walk_left;
    public KeyCode instance_walk_right;
    public KeyCode instance_jump;
    public KeyCode instance_jetpack;
    
}

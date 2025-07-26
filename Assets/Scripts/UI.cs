using UnityEngine;

[CreateAssetMenu(fileName = "UI", menuName = "Scriptable Objects/UI")]
public class UI : ScriptableObject {
    private static UI main;
    private GameObject ui_object;
    [SerializeField]
    private GameObject ui_prefab;
    public static void SetDialogueText(string text) {}
    public static void CloseDialogueText() {}
    public static void OpenDialogueText() {}
    public static void AddHP(int hp) {
        main.hp += hp;
    }
    public static void AddPlayerFuel(int fuel) {
        main.player_fuel += fuel;
    }
    public static void AddInstanceFuel(int fuel) {
        main.instance_fuel += fuel;
    }
    public static void AddBalance(int profit) {
        main.balance += profit;
    }
    private int hp = 0;
    private int player_fuel = 0;
    private int instance_fuel = 0;
    private int balance = 0;
    void OnEnable() {
        main = this;
        ui_object = Instantiate(ui_prefab);
        DontDestroyOnLoad(ui_object);
    }
}

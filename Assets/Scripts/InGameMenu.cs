using System.Runtime.CompilerServices;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public static InGameMenu menu;
    public GameObject inventory_button, abilities_button, options_button;
    public GameObject scroll_menu;
    public GameObject inventory_menu, abilities_menu, options_menu;
    public GameObject cached_inventory_menu, cached_abilities_menu, cached_options_menu;
    private bool is_open = false;
    private MenuState current_state;
    private Transform scroll_menu_parent;
    public void Toggle() {
        if (is_open)
            Close();
        else
            Open();
    }
    public void Open() {
        is_open = true;
        gameObject.SetActive(true);
    }
    public void Close() {
        is_open = false;
        gameObject.SetActive(false);
    }
    public void SwitchToPage(int page) {
        Destroy(scroll_menu);
        MenuState page_enum = (MenuState)page;
        switch (page_enum) {
            case MenuState.Inventory:
                if (!cached_inventory_menu)
                    cached_inventory_menu = inventory_menu;
                scroll_menu = Instantiate(cached_inventory_menu, scroll_menu_parent);
                Debug.Log("Switched to Inventory");
                break;
            case MenuState.Abilities:
                if (!cached_abilities_menu)
                    cached_abilities_menu = abilities_menu;
                scroll_menu = Instantiate(cached_abilities_menu, scroll_menu_parent);
                Debug.Log("Switched to Abilities");
                break;
            case MenuState.Options:
                if (!cached_options_menu)
                    cached_options_menu = options_menu;
                scroll_menu = Instantiate(cached_options_menu, scroll_menu_parent);
                Debug.Log("Switched to Options");
                break;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scroll_menu_parent = scroll_menu.transform.parent;
        menu = this;
        Close();
    }
}

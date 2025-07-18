using System.Runtime.CompilerServices;
using UnityEngine;

public class DynamicMenu : MonoBehaviour
{
    public static DynamicMenu menu;
    public GameObject inventory_prefab, abilities_prefab, options_prefab;
    public GameObject inventory, abilities, options;
    private GameObject open_page;
    private bool is_open = false;
    private MenuState current_state = MenuState.Inventory;
    public void Toggle() {
        if (is_open)
            Close();
        else
            Open((int)current_state);
    }
    public void Open(int page)
    {
        inventory.SetActive(false);
        abilities.SetActive(false);
        options.SetActive(false);
        if (!is_open)
        {
            is_open = true;
            OuterMenu.menu.gameObject.SetActive(true);
        }
        switch ((MenuState)page)
        {
            case MenuState.Inventory:
                inventory.SetActive(true);
                open_page = inventory;
                current_state = MenuState.Inventory;
                break;
            case MenuState.Abilities:
                inventory.SetActive(true);
                open_page = inventory;
                current_state = MenuState.Abilities;
                break;
            case MenuState.Options:
                inventory.SetActive(true);
                open_page = inventory;
                current_state = MenuState.Options;
                break;
        }
    }
    public void Close()
    {
        is_open = false;
        OuterMenu.menu.gameObject.SetActive(false);
    }


    void Start()
    {
        inventory = Instantiate(inventory_prefab);
        abilities = Instantiate(abilities_prefab);
        options = Instantiate(options_prefab);
        menu = this;
        Close();
    }
}

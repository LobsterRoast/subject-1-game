using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuGenerator : MonoBehaviour
{
    public GameObject inventory_slot_prefab;
    private List<GameObject> inventory_slots = new List<GameObject>();
    private int item_count = 8;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < item_count; i++) {
            RectTransform rt;
            inventory_slots.Add(Instantiate(inventory_slot_prefab));
            rt = inventory_slots[i].GetComponent<RectTransform>();
            rt.parent = this.gameObject.GetComponent<RectTransform>();
            Vector2 position = rt.anchoredPosition;
            Vector3 scale = rt.localScale;
            position.x = -400 + (100 * (i % 3));
            position.y = (1 - Mathf.Floor(i / 3f)) * 80;
            Debug.Log(position);
            scale.x = 0.5f;
            scale.y = 0.5f;
            rt.anchoredPosition = position;
            rt.localScale = scale;
        }
    }
}

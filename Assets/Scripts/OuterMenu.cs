using UnityEngine;

public class OuterMenu : MonoBehaviour
{
    public static OuterMenu menu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menu = this;
    }
}

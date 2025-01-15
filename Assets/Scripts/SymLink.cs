using UnityEngine;

public class SymLink : MonoBehaviour
{
    public Link[] links;
    public Link entrance_link;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        links = GetComponentsInChildren<Link>();
    }
}

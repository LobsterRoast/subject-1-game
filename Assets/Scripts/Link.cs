using UnityEngine;

public class Link : MonoBehaviour
{
    private SymLink symlink;
    void OnTriggerEnter(Collider collider) {
        if (symlink.entrance_link)
            return;
        else {
            symlink.entrance_link = this;
            Link exit_link = (this == symlink.links[0]) ? symlink.links[1] : symlink.links[0];
            collider.transform.position = exit_link.transform.position;
        }
    }

    void OnTriggerExit(Collider collider) {
        if (symlink.entrance_link != this)
            symlink.entrance_link = null;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        symlink = transform.parent.gameObject.GetComponent<SymLink>();
    }
}

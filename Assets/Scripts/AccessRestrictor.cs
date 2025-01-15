using UnityEngine;

public class AccessRestrictor : MonoBehaviour
{
    private Vector3 offset = new Vector3(0.0f, 2f, 0.0f);

    public GlobalInfo global_info;
    void OnCollisionStay(Collision other)
    {
        Controllable controllable;
        if (controllable = other.gameObject.GetComponent<Controllable>())
            controllable.taking_knockback = true;
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        Vector3 normal = other.GetContact(0).normal;
        Vector3 force = offset - normal * 6f;
        force.y *= global_info.gravity_fac;
        rb.AddForce(force, ForceMode.Impulse);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

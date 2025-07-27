using UnityEngine;

public class AccessRestrictor : MonoBehaviour
{
    private Vector3 offset = new Vector3(0.0f, 2f, 0.0f);
    public float knockback_fac = 15f;
    public float torque_fac = 2f;
    public GravitySystem gravity_system;
    void OnCollisionEnter(Collision other)
    {
        Controllable controllable;
        if (controllable = other.gameObject.GetComponent<Controllable>()) {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 normal = other.GetContact(0).normal;
            Vector3 force = offset - normal * knockback_fac;
            Vector3 torque = new Vector3(0f, 0f, normal.x) * torque_fac;
            force.y *= gravity_system.gravity_fac;
            controllable.DoKnockback(force, torque);
        }
    }
}

using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float velocity;
    public Vector3 direction;
    public void ActivateProjectile(Vector3 direction) {
        Rigidbody rb = GetComponent<Rigidbody>();
        this.direction = direction;
        rb.linearVelocity = direction * velocity;
    }
    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}

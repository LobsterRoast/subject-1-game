using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Entity sender;
    public float velocity;
    public Vector3 direction;
    public int damage;
    public void ActivateProjectile(Vector3 direction, Entity sender) {
        Rigidbody rb = GetComponent<Rigidbody>();
        this.direction = direction;
        this.sender = sender;
        rb.linearVelocity = direction * velocity;
    }
    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}

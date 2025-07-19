using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static Projectile[] pool = new Projectile[20];
    public Rigidbody rb;
    public Entity sender;
    public float velocity;
    public Vector3 direction;
    public int damage;
    public WeaponTag weapon_tag;
    public void ActivateProjectile(Entity sender, float velocity, Vector3 direction, int damage, WeaponTag weapon_tag = WeaponTag.Null) {
        this.sender = sender;
        this.damage = damage;
        this.weapon_tag = weapon_tag;
        if (!rb)
            rb = GetComponent<Rigidbody>();
        rb.linearVelocity = direction * velocity;
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}

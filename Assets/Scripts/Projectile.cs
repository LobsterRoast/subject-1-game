using UnityEngine;
using System.Collections.Generic;

public class Projectile : MonoBehaviour
{
    public ObjectPool pool;
    public GameObject projectile_object;
    public Collider collider;
    public MeshFilter mesh_filter;
    public MeshRenderer mesh_renderer;
    public Rigidbody rb;
    public Entity sender;
    public float velocity;
    public Vector3 direction;
    public int damage;
    public WeaponTag weapon_tag;
    public void ActivateProjectile(Entity sender, float velocity, Vector3 position, Vector3 direction, int damage, WeaponTag weapon_tag = WeaponTag.Null) {
        gameObject.SetActive(true);
        transform.position = position;
        this.sender = sender;
        this.damage = damage;
        this.weapon_tag = weapon_tag;
        if (!rb)
            rb = GetComponent<Rigidbody>();
        rb.linearVelocity = direction * velocity;
    }

    void OnCollisionEnter(Collision other)
    {
        pool.pool.Add(this);
        gameObject.SetActive(false);
    }
}

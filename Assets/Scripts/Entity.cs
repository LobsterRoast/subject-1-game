using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

[RequireComponent(typeof(Rigidbody))]
public abstract class Entity : MonoBehaviour {
    public static Entity[] entities;
    public int max_hp;
    private int health;
    protected GravitySystem gravity_system = GravitySystem.main;
    public abstract EntityType entity_type { get; }
    protected abstract void OnProjectileHit(Projectile projectile);
    public virtual void OnWallCollide(RaycastHit hit) { }
    protected abstract void OnDeath();
    public virtual void Start() {
        health = max_hp;
        rb = GetComponent<Rigidbody>();
        StartCoroutine(CheckGravity());
    }
    public virtual void Update() {
    }
    public virtual void FixedUpdate() {
    }
    public virtual void Awake() {
        GetVariables();
    }
    public void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.layer) {
            case 10:
                OnProjectileHit(collision.gameObject.GetComponent<Projectile>());
                break;
        }
    }
    public void Damage(int dmg) {
        health = Mathf.Clamp(health - dmg, 0, max_hp);
        if (health <= 0)
            OnDeath();
    }
    public static IEnumerator CheckGravity() {
        bool gravity_inverted = false;
        while (true) {
            if (Physics.gravity.y < 0f && gravity_inverted) {
                gravity_inverted = false;
                InvertEntityScale();
            }
            else if (Physics.gravity.y > 0f && !gravity_inverted) {
                gravity_inverted = true;
                InvertEntityScale();
            }
            yield return null;
        }
    }
    protected Rigidbody rb;
    protected bool GroundCheck() {
        return Physics.Raycast(new Ray(transform.position, gravity_system.gravity_fac * Vector3.down), 1.05f, 1 << 3);
    }
    protected virtual void GetVariables() {
        rb = GetComponent<Rigidbody>();
    }

    private static void InvertEntityScale() {
        foreach (Entity entity in entities) {
            entity.transform.localScale = new Vector3(entity.transform.localScale.x,
                                                      entity.transform.localScale.y * -1,
                                                      entity.transform.localScale.z);
        }
    }
}

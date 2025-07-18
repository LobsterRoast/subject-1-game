using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Entity : MonoBehaviour {
    public GlobalInfo global_info;
    public static Entity[] entities;
    public int max_hp;
    private int health;
    public abstract EntityType entity_type { get; }
    protected abstract void OnProjectileHit(Projectile projectile);
    public virtual void OnWallCollide(RaycastHit hit) { }
    protected abstract void OnDeath();

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
    public virtual void Start() {
        health = max_hp;
        StartCoroutine(CheckGravity());
    }
    protected bool GroundCheck() {
        return Physics.Raycast(new Ray(transform.position, global_info.gravity_fac * Vector3.down), 1.05f, 1 << 3);
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

    private static void InvertEntityScale() {
        foreach (Entity entity in entities) {
            entity.transform.localScale = new Vector3(entity.transform.localScale.x,
                                                      entity.transform.localScale.y * -1,
                                                      entity.transform.localScale.z);
        }
    }
    public virtual void Update() {
        
    }
}

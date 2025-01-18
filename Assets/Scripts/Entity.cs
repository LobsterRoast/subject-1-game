using UnityEngine;

public abstract class Entity : MonoBehaviour {
    public int max_hp;
    private int health;
    public abstract EntityType entity_type { get; }
    protected abstract void OnProjectileHit(Projectile projectile);
    protected abstract void OnDeath();
    public void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == 10) {
            OnProjectileHit(collision.gameObject.GetComponent<Projectile>());
        }
    }
    public void Damage(int dmg) {
        health = Mathf.Clamp(health - dmg, 0, max_hp);
        if (health <= 0)
            OnDeath();
    }
    public void Start() {
        health = max_hp;
    }
}

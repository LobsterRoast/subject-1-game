using UnityEngine;

public class Enemy : Entity
{
    public override EntityType entity_type { get { return EntityType.Enemy; } }
    protected override void OnDeath() {
        Debug.Log("Enemy Died!");
        Destroy(gameObject);
    }
    protected override void OnProjectileHit(Projectile projectile) {
        if (projectile.sender.entity_type == EntityType.Player) {
            Damage(projectile.damage);
        }
    }
}

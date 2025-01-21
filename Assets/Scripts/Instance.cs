public class Instance : ControllableEntity {
    public override EntityType entity_type { get { return EntityType.Instance; } }
    protected override void OnProjectileHit(Projectile projectile) {}
    protected override void OnDeath() {}
}
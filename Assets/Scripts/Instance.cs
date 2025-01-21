public class Instance : ControllableEntity {
    // Static reference to the instance, since there should only be one at a time
    public static Instance main;
    public override EntityType entity_type { get { return EntityType.Instance; } }
    protected override void OnProjectileHit(Projectile projectile) {}
    protected override void OnDeath() {}
    public void Start() {
        main = this;
    }
}
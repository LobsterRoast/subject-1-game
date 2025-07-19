using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
public abstract class Weapon : ScriptableObject {
    public ObjectPool pool;
    public GameObject projectile_prefab;
    public float velocity;
    public int damage;
    public virtual void Fire(Entity sender) {
        Projectile proj = pool.GetProjectileFromPool();
        proj.ActivateProjectile(sender, velocity, sender.transform.position, FindDirection(), damage);
    }
    public virtual void Fire(Entity sender, Vector3 direction_screen_space) {
        Projectile proj = pool.GetProjectileFromPool();
    }
    private Vector3 FindDirection() {
        Vector3 mouse_pos = Input.mousePosition;
        mouse_pos.x -= Screen.width / 2;
        mouse_pos.y -= Screen.height / 2;
        return mouse_pos.normalized;
    }
}

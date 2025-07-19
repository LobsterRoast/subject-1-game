using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
public abstract class Weapon : ScriptableObject {
    public GameObject projectile;
    public float velocity;
    public int damage;
    public virtual void Fire(Entity entity) {
        Vector3 direction = FindDirection();
        Instantiate(new Projectile(entity, velocity, direction, damage));
    }
    public virtual void Fire(Entity entity, Vector3 direction_screen_space) {
        Instantiate(new Projectile(entity, velocity, direction_screen_space, damage));
    }
    private Vector3 FindDirection() {
        Vector3 mouse_pos = Input.mousePosition;
        mouse_pos.x -= Screen.width / 2;
        mouse_pos.y -= Screen.height / 2;
        return mouse_pos;
    }
}

using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Weapon held_weapon;

    private void CreateProjectile(Vector3 direction, Entity sender) {
        //GameObject projectile_obj = Instantiate(held_weapon.projectile, transform.position, transform.rotation);
        //projectile_obj.GetComponent<Projectile>().ActivateProjectile(direction, sender);
        //projectile_obj.transform.SetParent(null, false);
    }
    public void Attack(Vector3 direction, Entity sender) {
        //CreateProjectile(direction, sender);
    }
}

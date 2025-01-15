using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Weapon held_weapon;

    private void CreateProjectile(Vector3 direction) {
        GameObject projectile_obj = Instantiate(held_weapon.projectile, transform.position, transform.rotation);
        projectile_obj.GetComponent<Projectile>().ActivateProjectile(direction);
        projectile_obj.transform.parent = null;
    }
    public void Attack(Vector3 direction) {
        CreateProjectile(direction);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

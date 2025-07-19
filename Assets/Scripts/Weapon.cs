using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
public abstract class Weapon : ScriptableObject {
    public GameObject projectile;
    public float damage;
    public virtual void Fire() {}
}

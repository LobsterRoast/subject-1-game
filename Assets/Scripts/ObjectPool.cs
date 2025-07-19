using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ObjectPool", menuName = "Scriptable Objects/ObjectPool")]
public class ObjectPool : ScriptableObject {
    public GameObject basic_projectile;
    public List<Projectile> pool = new List<Projectile>(20);
    void OnEnable() {
        pool = new List<Projectile>();
    }
    private Projectile AddNewProjectile() {
        GameObject obj = Instantiate(basic_projectile);
        Projectile proj = obj.GetComponent<Projectile>();
        proj.rb = proj.GetComponent<Rigidbody>();
        proj.collider = proj.GetComponent<Collider>();
        proj.mesh_filter = proj.GetComponent<MeshFilter>();
        proj.mesh_renderer = proj.GetComponent<MeshRenderer>();
        proj.projectile_object = obj;
        proj.pool = this;
        return proj;
    }
    // Gets a reference to an object from the pool or creates one if theres none available
    public Projectile GetProjectileFromPool() {
        if (pool.Count == 0) {
            return AddNewProjectile();
        }
        else {
            Projectile proj = pool[0];
            pool.Remove(pool[0]);
            return proj;
        }
    }
}
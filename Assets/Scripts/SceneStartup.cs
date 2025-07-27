using UnityEngine;

public class SceneStartup : MonoBehaviour
{
    private GravitySystem gravity_system;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gravity_system = GravitySystem.main;
        Entity.entities = FindObjectsByType<Entity>(FindObjectsSortMode.None);
        Physics.gravity = new Vector3(0.0f, -19.62f, 0.0f);
        gravity_system.gravity_fac = 1f;
        gravity_system.gravity_multiplier = 1f;
        StartCoroutine(Entity.CheckGravity());
    }
}

using UnityEngine;

public class SceneStartup : MonoBehaviour
{
    public GlobalInfo global_info;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics.gravity = new Vector3(0.0f, -19.62f, 0.0f);
        global_info.gravity_fac = 1f;
        global_info.gravity_multiplier = 1f;
    }
}

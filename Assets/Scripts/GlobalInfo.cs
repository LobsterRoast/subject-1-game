using UnityEngine;

[CreateAssetMenu(fileName = "GlobalInfo", menuName = "Scriptable Objects/GlobalInfo")]
public class GlobalInfo : ScriptableObject
{
    public float gravity_fac = 1.0f;
    public float gravity_multiplier = 1.0f;
    public void ChangeGravity(float fac) {
        gravity_multiplier = Mathf.Clamp(gravity_multiplier + fac, -1.0f, 1.0f);
        Physics.gravity = new Vector3(0.0f, -19.62f * gravity_multiplier, 0.0f);
        gravity_fac = gravity_multiplier < 0f ? -1f : 1f;
    }
}

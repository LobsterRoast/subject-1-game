using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private Transform player_tf;
    private GravitySystem gravity_system;
    private Vector3 FindTargetPosition(Vector3 player_position) {
        float offset = Mathf.Pow(2.0f * Mathf.Abs(gravity_system.gravity_multiplier), 1f/3f) * gravity_system.gravity_fac;
        return new Vector3(player_position.x, player_position.y + offset, -12.0f);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_tf = PlayerNew.player.transform;
        gravity_system = GravitySystem.main;
        player_tf = GameObject.FindWithTag("Player").transform;
        transform.position = FindTargetPosition(player_tf.position);
    }
    void FixedUpdate()
    {
        Vector3 target_position = FindTargetPosition(player_tf.position);
        Vector3 translation_vector = Vector3.Normalize(target_position - transform.position);
        transform.Translate(translation_vector * Vector3.Distance(transform.position, target_position)/4.0f);
    }
}

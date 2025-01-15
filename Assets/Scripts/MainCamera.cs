using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player_tf;
    private Vector3 FindTargetPosition(Vector3 player_position) {
        float offset = Mathf.Pow(2.0f * Mathf.Abs(global_info.gravity_multiplier), 1f/3f) * global_info.gravity_fac;
        return new Vector3(player_position.x, player_position.y + offset, -12.0f);
    }

    public GlobalInfo global_info;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_tf = GameObject.FindWithTag("Player").transform;
        transform.position = FindTargetPosition(player_tf.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 target_position = FindTargetPosition(player_tf.position);
        Vector3 translation_vector = Vector3.Normalize(target_position - transform.position);
        transform.Translate(translation_vector * Vector3.Distance(transform.position, target_position)/4.0f);
    }
}

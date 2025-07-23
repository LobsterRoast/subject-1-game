using UnityEngine;
using System.Collections;

public class Flanker : Enemy
{
    public float velocity;
    public float torque;
    public float teleport_radius;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        StartCoroutine(Charge());
        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    private Vector3 FindTeleportPosition(Vector3 player_position)
    {
        Vector3 difference_vector = transform.position - player_position;
        Vector3 opposite_vector = player_position - difference_vector;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, opposite_vector, teleport_radius, 1 << 3))
            return transform.position;
        else
            return opposite_vector;
    }

    private Vector3 GetMovementVector() {
        return (PlayerNew.player.transform.position - transform.position).normalized;
    }
    [ContextMenu("Charge")]
    private IEnumerator Charge()
    {
        while (true)
        {
            rb.linearVelocity = GetMovementVector() * velocity;
            StartCoroutine(TeleportCoroutine());
            yield return new WaitForSeconds(5);
        }
    }

    private IEnumerator TeleportCoroutine()
    {
        Vector3 player_position = PlayerNew.player.transform.position;
        while (true)
        {
            if (!(Vector3.Distance(transform.position, player_position) <= teleport_radius))
            {
                yield return null;
                continue;
            }
            if (rb.linearVelocity.magnitude < 4f)
            {
                yield return new WaitForSeconds(5);
                continue;
            }
            Vector3 teleport_position = FindTeleportPosition(player_position);
            if (teleport_position == transform.position)
            {
                yield return new WaitForSeconds(5);
                continue;
            }
            transform.position = teleport_position;
            rb.linearVelocity = GetMovementVector() * rb.linearVelocity.magnitude;
            yield return new WaitForSeconds(5);
        }
    }
}

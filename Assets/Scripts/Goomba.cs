using UnityEngine;

public class Goomba : Enemy
{
    public Rigidbody rb;
    public Vector3 direction = new Vector3(1, 0, 0);
    public Mesh mesh;
    public float velocity;
    public override void OnWallCollide(RaycastHit hit) {
        direction *= -1;
        Debug.Log("Wall collision");
        Debug.Log(hit.collider.gameObject);

    }
    void Update()
    {
        float bottom = transform.position.y + mesh.bounds.min.y;
            if(GroundCheck())
        rb.linearVelocity = direction * velocity;
        if (Physics.Raycast(new Ray(new Vector3(transform.position.x, bottom, transform.position.z), direction * (mesh.bounds.max.x + 0.05f)),
            out hit,
            (mesh.bounds.max.x + 0.05f),
            1 << 3))
        {
            OnWallCollide(hit);
        }
        Debug.DrawRay(new Vector3(transform.position.x, bottom, transform.position.z), direction * (mesh.bounds.max.x+0.05f), Color.blue, 0.0f, false);
    }
    public override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshFilter>().mesh;
    }
}
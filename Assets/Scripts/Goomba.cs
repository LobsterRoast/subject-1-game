using UnityEngine;

public class Goomba : Enemy
{
    public Rigidbody rb;
    public Vector3 direction = new Vector3(1, 0, 0);
    public Mesh mesh;
    public float velocity;
    public override void OnWallCollide(RaycastHit hit)
    {
        direction *= -1;
        Debug.Log("Wall collision");

    }
    void Update()
    {
        rb.AddForce(direction * velocity, ForceMode.Acceleration);
        if (Physics.Raycast(new Ray(transform.position, transform.forward * (mesh.bounds.max.x + 0.05f)),
            out hit,
            Mathf.Infinity,
            1 << 3))
        {
        if(hit.collider.gameObject.layer == 3)
            OnWallCollide(hit);
        }
        Debug.DrawRay(transform.position, transform.forward*(mesh.bounds.max.x+0.05f), Color.blue, 0.0f, false);
    }
    protected override void UnhidableStart()
    {
        rb = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshFilter>().mesh;
    }
}
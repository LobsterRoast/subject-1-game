using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FragileFloor : MonoBehaviour
{
    public float integrity;
    private AudioSource audio;
    private ParticleSystem particle_system;
    private ParticleSystem.ShapeModule shape;
    private void Break(Vector3 normal, float vel)
    {
        shape.rotation = Quaternion.LookRotation(normal).eulerAngles;
        particle_system.startSpeed = vel - integrity;
        particle_system.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude > integrity)
        {
            Break(collision.contacts[(int)(collision.contactCount/2)].normal, collision.relativeVelocity.magnitude);
            collision.rigidbody.linearVelocity = collision.relativeVelocity;
        }
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
        particle_system = GetComponent<ParticleSystem>();
        shape = particle_system.shape;
    }
}

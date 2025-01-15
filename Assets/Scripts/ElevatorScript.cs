using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : Saveable
{
    private Transform start_point;
    private Transform end_point;
    private Transform target;
    private Transform rail;
    public float velocity;
    public Transform saved_target;


    public override void ScriptableSave() {
        saved_target = target;
    }
    public override void ScriptableLoad() {
        target = saved_target;
    }
    // Start is called before the first frame update
    void Start()
    {
        rail = transform.Find("ElevatorRail");
        start_point = rail.Find("StartPoint");
        end_point = rail.Find("EndPoint");
        transform.position = start_point.position;
        target = end_point;
        rail.parent = null;
    }
    void OnCollisionEnter(Collision other) {
        other.gameObject.transform.parent = transform;
    }
    void OnCollisionExit(Collision other) {
        other.gameObject.transform.parent = null;
    }
    void FixedUpdate() {
        Vector3 pos = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target.position , velocity);
        Vector3 dpos = transform.position;
        if (dpos - pos == Vector3.zero) {
            target = target == start_point ? end_point : start_point;
        }
    }
}

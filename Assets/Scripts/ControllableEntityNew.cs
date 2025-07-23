using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class ControllableEntityNew : Entity {
    public override void Start() {
        base.Start();
        SetVariables();
    }
    public override void Update() {
        base.Update();
        PreInputs();
        GetInputs();
    }
    public override void FixedUpdate() {
        base.FixedUpdate();
        Vector3 vel = rb.linearVelocity;
        vel.x *= 1 - linear_damping.x * Time.deltaTime;
        rb.linearVelocity = vel;
    }
    protected void WalkLeft() {
        rb.linearVelocity = new Vector3(-walk_velocity, rb.linearVelocity.y, rb.linearVelocity.z);
    }
    protected void WalkRight() {
        rb.linearVelocity = new Vector3(walk_velocity, rb.linearVelocity.y, rb.linearVelocity.z);
    }
    protected void Jump() {
        Vector3 vel = rb.linearVelocity;
        vel.y = jump_velocity;
        rb.linearVelocity = vel;
    }
    protected void Jetpack() { }
    protected void ToggleInstance() { }
    protected void EngageOrAdvanceDialogue() { }
    protected void ToggleMenu() { }
    protected bool is_grounded;
    protected Keybinds keybinds = Keybinds.main;
    [SerializeField]
    protected float walk_velocity;
    [SerializeField]
    protected float jump_velocity;
    [SerializeField]
    // linearDamping in a Rigidbody is a float thats applied to every axis. This movement system reimplements it as a Vector3 so that it can be applied on a per-axis basis.
    protected Vector3 linear_damping;
    protected Collider collider;
    protected bool can_double_jump = true;
    protected abstract FillMeter jetpack_fuel_meter { get; }
    // This is run before inputs are checked
    protected virtual void PreInputs() {
        is_grounded = GroundCheck();
        if (is_grounded)
            can_double_jump = true;
    }
    protected virtual void SetVariables() {
        collider = GetComponent<Collider>();
    }
    // This is the function to check inputs and must be implemented by each Controllable individually
    protected abstract void GetInputs();

}
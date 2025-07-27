using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Controllable : MonoBehaviour {
    // Privates
    private Rigidbody rb;
    private float dx;
    [SerializeField] private bool is_grounded;
    private float jetpack_fuel = 10000f;
    private bool jetpack_acquired = true;
    private bool double_jump_available;
    private Collider collider;

    protected KeyCode walk_left { get; set; }
    protected KeyCode walk_right { get; set; }
    protected KeyCode jump { get; set; }
    protected KeyCode jetpack { get; set; }
    // Publics
    public ControllableEntity entity;
    public Keybinds bindings;
    public GravitySystem gravity_system;
    public float velocity;
    public Vector3 jump_vector;
    public Vector3 jetpack_vector;
    public bool taking_knockback;
    public PhysicsMaterial physics_material;
    
    // This is a separate start function that doesn't hide the main one
    protected abstract void ControllableStart();
    protected abstract FillMeter jetpack_fuel_meter_prop { get; }

    protected abstract void PrefabSpecificInputs();
    public void DoKnockback(Vector3 force, Vector3 torque) {
        taking_knockback = true;
        rb.constraints ^= RigidbodyConstraints.FreezeRotationZ;
        rb.AddForce(force, ForceMode.Impulse);
        rb.AddTorque(torque, ForceMode.Impulse);
        collider.material = null; 
    }
    void OnCollisionExit(Collision other) {
    }
    private void SetVerticalVelocityZero() {
        Vector3 vel = rb.linearVelocity;
        vel.y = 0f;
        rb.linearVelocity = vel;
    }
    private void UseJetpack() {
        if (entity.CheckAccessory(Accessory.Jetpack)) {
            rb.AddForce(jetpack_vector * Time.deltaTime * gravity_system.gravity_fac, ForceMode.Acceleration);
            jetpack_fuel = Mathf.Clamp(jetpack_fuel - 0.1f, 0.0f, 10000.0f);
            jetpack_fuel_meter_prop.SetFillAmount(jetpack_fuel/100.0f);
        }
    }

    private void GroundCheck() {
        is_grounded = Physics.Raycast(new Ray(transform.position, gravity_system.gravity_fac * Vector3.down), 1.05f, 1 << 3);
        if (is_grounded)
            double_jump_available = true;
    }
    private void SetVariables() {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void Jump() {
        SetVerticalVelocityZero();
        transform.rotation = new Quaternion(90f, 0f, 0f, 0f);
        if (taking_knockback) {
            taking_knockback = false;
            collider.material = physics_material;
            rb.constraints |= RigidbodyConstraints.FreezeRotationZ;
        }
        rb.AddForce(gravity_system.gravity_fac * jump_vector, ForceMode.Force);
    }
    private void DoubleJump() {
        Jump();
        double_jump_available = false;
    }
    private void ApplyMovementVector() {
        rb.linearVelocity = new Vector3(dx, rb.linearVelocity.y, rb.linearVelocity.z);
    }
    private void CheckInputs() {
        if (!taking_knockback) {
            dx = 0.0f;
            if (Keybinds.GetInput(walk_left)) {
                dx = -velocity;
            }
            if (Keybinds.GetInput(walk_right)) {
                dx = velocity;
            }
            ApplyMovementVector();

            if (Keybinds.GetInput(jetpack) &&
                jetpack_fuel > 0.0f &&
                (entity.active_accessory & Accessory.Jetpack) != Accessory.None) {
                UseJetpack();
            }
        }
        if (Keybinds.GetInputDown(jump)) {
            if (is_grounded) {
                Jump();
            }
            else if (double_jump_available && !taking_knockback) {
                DoubleJump();
            }
        }
        PrefabSpecificInputs();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetVariables();
        ControllableStart();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        CheckInputs();
    }

}

using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Controllable : MonoBehaviour {
    // Privates
    private Rigidbody rb;
    private float dx;
    [SerializeField] private bool is_grounded;
    private float jetpack_fuel = 100f;
    private bool jetpack_acquired = true;
    private bool double_jump_available;

    // Publics
    public ControllableEntity entity;
    public GlobalInfo global_info;
    public float velocity;
    public Vector3 jump_vector;
    public Vector3 jetpack_vector;
    public bool taking_knockback;
    public KeyCode walk_left;
    public KeyCode walk_right;
    public KeyCode jump;
    public KeyCode jetpack;
    
    // Protecteds
    protected abstract void ControllableStart();
    protected abstract FillMeter jetpack_fuel_meter_prop { get; }

    protected abstract void PrefabSpecificInputs();
    void OnCollisionEnter(Collision other) {
        taking_knockback = false;
    }
    void OnCollisionExit(Collision other) {
    }
    private void SetVerticalVelocityZero() {
        Vector3 vel = rb.linearVelocity;
        vel.y = 0f;
        rb.linearVelocity = vel;
    }
    private void UseJetpack() {
        rb.AddForce(jetpack_vector * Time.deltaTime * global_info.gravity_fac, ForceMode.Force);
        jetpack_fuel = Mathf.Clamp(jetpack_fuel - 0.1f, 0.0f, 100.0f);
        jetpack_fuel_meter_prop.SetFillAmount(jetpack_fuel/100.0f);
    }

    private void GroundCheck() {
        is_grounded = Physics.Raycast(new Ray(transform.position, global_info.gravity_fac * Vector3.down), 1.05f, 1 << 3);
        if (is_grounded)
            double_jump_available = true;
    }
    private void SetVariables() {
        rb = GetComponent<Rigidbody>();
    }

    private void Jump() {
        SetVerticalVelocityZero();
        rb.AddForce(global_info.gravity_fac * jump_vector, ForceMode.Force);
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
            if (Input.GetKey(walk_left)) {
                dx = -velocity;
            }
            if (Input.GetKey(walk_right)) {
                dx = velocity;
            }
            if (Input.GetKeyDown(jump)) {
                if (is_grounded) {
                    Jump();
                }
                else if (double_jump_available) {
                    DoubleJump();
                }
            }
            ApplyMovementVector();

            if (Input.GetKey(jetpack) &&
                jetpack_fuel > 0.0f &&
                (entity.active_accessory & Accessory.Jetpack) != Accessory.None) {
                UseJetpack();
            }
        }
        PrefabSpecificInputs();

    }
    private void ClampVelocity() {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, Mathf.Min(rb.linearVelocity.y, 15.0f), rb.linearVelocity.z);
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
        ClampVelocity();
    }

}

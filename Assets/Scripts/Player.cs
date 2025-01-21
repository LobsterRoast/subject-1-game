using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Player : ControllableEntity
{
    // Static reference to the player, since there should only be one at a time
    public static Player main;
    public Image health_bar;
    public SaveData save_data;
    public Rigidbody rb;
    public override EntityType entity_type { get { return EntityType.Player; } }
    [ContextMenu("Damage Player")]
    protected override void OnProjectileHit(Projectile projectile) {
        
    }
    public void DamageTest() {
        Damage(10);
    }
    protected override void OnDeath() {
        Die();
    }
    [ContextMenu("Kill Player")]
    public void KillPlayer() {
        StartCoroutine(Die());
    }
    public IEnumerator Die() {
        transform.parent = null;
        float scale = 1f;
        Vector3 position = transform.position;
        Vector3 cam_position = Camera.main.transform.position;
        rb.useGravity = false;
        while (scale > 0.1f) {
            transform.parent = null;
            scale *= 0.9f;
            transform.localScale *= 0.9f;
            yield return new WaitForSeconds(0.025f);
        }
        rb.useGravity = true;
    }
    public void Start() {
        main = this;
        active_accessory |= Accessory.Gravity_Manipulator;
        active_accessory |= Accessory.Jetpack;
        active_accessory |= Accessory.Instantiator;
    }
}

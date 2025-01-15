using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public Image health_bar;
    public SaveData save_data;
    public Rigidbody rb;

    [ContextMenu("Damage Player")]
    public void DamageTest() {
        Damage(10);
    }
    public void Damage(int damage) {
        health = Mathf.Clamp(health - damage, 0, 100);
        health_bar.fillAmount = health/100f;
        if (health <= 0)
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
        save_data.LoadSceneData();
        rb.useGravity = true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Die();
    }
}

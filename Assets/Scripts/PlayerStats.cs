using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public Image health_bar;

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
    public void Die() {

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

using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;

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

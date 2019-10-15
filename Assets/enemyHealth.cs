using UnityEngine;

public class enemyHealth : MonoBehaviour {

    public enemyScriptableObject enemy;
    public float currentHealth;

    private void Start() {
        currentHealth = enemy.health;
    }

    private void Update() {
        CheckHealth();
    }

    private void CheckHealth() {
        if(currentHealth <= 0) {
            killEnemy();
        }
    }

    private void killEnemy() {
        FindObjectOfType<enemyManager>().enemies.Remove(gameObject);
        Destroy(gameObject);
    }

    public void TakeDamage(float amount) {
        currentHealth -= amount;
    }
}

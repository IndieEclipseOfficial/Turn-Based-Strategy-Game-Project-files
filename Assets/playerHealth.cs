using UnityEngine;

public class playerHealth : MonoBehaviour {

    public float currentHealth;

    private void Update() {
        if(currentHealth <= 0) {
            FindObjectOfType<selectionManager>().Characters.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    public void takeDamage(float value) {
        currentHealth -= value;
    }
}

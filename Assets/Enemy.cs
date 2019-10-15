using UnityEngine;

public class Enemy : MonoBehaviour {
    
    public void attackPlayer() {
        var randomPlayer = Random.Range(0, FindObjectOfType<selectionManager>().Characters.Count);
        FindObjectOfType<selectionManager>().Characters[randomPlayer].GetComponent<playerHealth>().takeDamage(GetComponent<enemyHealth>().enemy.damage);
    }
}

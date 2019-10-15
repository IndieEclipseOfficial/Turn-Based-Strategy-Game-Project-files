using UnityEngine;
using System.Collections.Generic;

public class enemyManager : MonoBehaviour {

    public List<GameObject> enemies = new List<GameObject>();

    public void attackCharacters() {
        foreach (var enemy in enemies) {
            enemy.GetComponent<Enemy>().attackPlayer();
        }
    }
}

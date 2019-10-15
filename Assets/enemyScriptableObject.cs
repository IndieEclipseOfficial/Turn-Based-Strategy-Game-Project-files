using UnityEngine;

[CreateAssetMenu(fileName = "new Enemy", menuName = "Enemy")]
public class enemyScriptableObject : ScriptableObject {

    public string enemyName;
    public float damage;
    public float health;
}

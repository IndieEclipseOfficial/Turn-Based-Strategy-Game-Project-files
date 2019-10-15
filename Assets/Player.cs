using UnityEngine;

public class Player : MonoBehaviour {

    private bool ableToAttack = false;
    private bool attacked = false;
    public float damage;

    public void setDamage(float value) {
        damage = value;
    }

    public void setAbleToAttack(bool value) {
        ableToAttack = value;
    }

    public void setAttacked(bool value) {
        attacked = value;
    }

    public float getDamage() {
        return damage;
    }

    public bool getAbleToAttack() {
        return ableToAttack;
    }

    public bool getAttacked() {
        return attacked;
    }
}

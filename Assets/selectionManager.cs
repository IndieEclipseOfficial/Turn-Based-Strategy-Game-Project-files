using UnityEngine;
using System.Collections.Generic;

public class selectionManager : MonoBehaviour {

    private RaycastHit2D hit;
    private Vector2 mousePosition;
    public GameObject attackButton;
    public Player player;
    public List<GameObject> Characters = new List<GameObject>();
    public bool ableToAttack = false;

    private void Update() {
        CheckInputs();
    }

    private void CheckInputs() {
        if(FindObjectOfType<enemyManager>().enemies.Count == 0) {
            print("You won!");
        }
        else if(FindObjectOfType<enemyManager>().enemies.Count != 0 && Characters.Count == 0) {
            print("You lost");
        }


        if (Input.GetMouseButton(0)) {
            if(getRayCastHit2D().collider != null){
                if (getRayCastHit2D().collider.CompareTag("Player")) {
                    player = getRayCastHit2D().collider.GetComponent<Player>();

                    if(player != null) {
                        switch (player.getAbleToAttack()) {
                            case true:
                                print("cant attack your character!");
                                break;
                            case false:
                                switch (player.getAttacked()) {
                                    case true:
                                        break;
                                    case false:
                                        attackButton.SetActive(true);
                                        break;
                                }
                                break;
                        }
                    }
                }
                else if (getRayCastHit2D().collider.CompareTag("Enemy")) {
                    switch (player.getAbleToAttack() && !player.getAttacked()) {
                        case true:
                            var missedAttackChance = Random.Range(0, 2);

                            switch (missedAttackChance) {
                                case 0:
                                    print("Missed Attack");
                                    break;
                                default:
                                    getRayCastHit2D().collider.GetComponent<enemyHealth>().TakeDamage(player.getDamage());
                                    print("Hit Enemy");
                                    break;
                            }

                            attackButton.SetActive(false);
                            player.setAttacked(true);
                            player.setAbleToAttack(false);
                            break;
                        case false:
                            print("You have to click the button!");
                            break;
                    }
                }
            }
        }
    }

    public void endTurn() {
        foreach (var character in Characters) {
            character.GetComponent<Player>().setAttacked(false);
            character.GetComponent<Player>().setAbleToAttack(false);
        }

        FindObjectOfType<enemyManager>().attackCharacters();
    }

    public void clickAttackButton() {
        player.setAbleToAttack(true);
    }

    private RaycastHit2D getRayCastHit2D() {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity);
        return hit;
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sign_Controler : MonoBehaviour {

    public GameObject dialogBox;
    public Text dialogText;
    public string dialoge;
    public bool playerInRange;

    public Animator animator;

    private void Update() {
        //THIS IS NOT EFFICIENT YOU SHOULD FIX THIS ASAP
        //IS THERE A WAY OF DOING THIS OTHER THAN NESTED IFS?
        if (playerInRange) {
            if (Input.GetButtonDown("Interact")) {
                if (dialogBox.activeInHierarchy) {
                    Time.timeScale = 1f;
                    dialogBox.SetActive(false);
                } else {
                    dialogBox.SetActive(true);
                    dialogText.text = dialoge;
                    Time.timeScale = 0f;
                }
            } else if (Input.GetButtonDown("Cancel")) {
                if (dialogBox.activeInHierarchy) {
                    Time.timeScale = 1f;
                    dialogBox.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            animator.SetTrigger("Entering");
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            animator.SetTrigger("Exiting");
            playerInRange = false;
        }
    }
}

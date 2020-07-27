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
        if (Input.GetButtonDown("Interact") && playerInRange) {
            if (dialogBox.activeInHierarchy) {
                Time.timeScale = 1f;
                dialogBox.SetActive(false);
            } else {
                dialogBox.SetActive(true);
                dialogText.text = dialoge;
                Time.timeScale = 0f;
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
        if (collision.CompareTag("Player")){
            animator.SetTrigger("Exiting");
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}

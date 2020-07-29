using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class NPC_Controler : MonoBehaviour
{

    public bool playerInRange = false;
    public Animator animator;
    public GameObject dialogBox;


    [SerializeField]private TextAssetValue dialogValue;
    [SerializeField] private TextAsset dialog;
    [SerializeField] private Notification dynamicDialogNotification;

    // Update is called once per frame
    void Update()
    {
        if (playerInRange) {
            if (Input.GetButtonDown("Interact")) {
                if (dialogBox.activeInHierarchy) {
                    Time.timeScale = 1f;
                    dialogBox.SetActive(false);
                } else {
                    dialogValue.value = dialog;
                    dialogBox.SetActive(true);
                    
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

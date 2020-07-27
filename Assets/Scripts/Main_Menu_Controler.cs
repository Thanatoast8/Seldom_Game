using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Controler : MonoBehaviour {

    public GameObject OptionsMenu;
    public GameObject MainMenu;
    public bool IsInOptions;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void loadGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void exitGame() {
        Application.Quit();
        Debug.Log("Quitting Game");
    }

    public void Options() {
        if (IsInOptions) {
            OptionsMenu.SetActive(false);
            MainMenu.SetActive(true);
            IsInOptions = false;
        } else {
            OptionsMenu.SetActive(true);
            MainMenu.SetActive(false);
            IsInOptions = true;
        }
    }
}

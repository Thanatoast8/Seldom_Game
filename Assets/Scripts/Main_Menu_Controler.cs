using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Controler : MonoBehaviour {

    public GameObject OptionsMenu;
    public GameObject MainMenu;
    public bool IsInOptions = false;

    public void loadGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void exitGame() {
        Application.Quit();
        Debug.Log("Quitting Game");
    }

    public void Options() {
        if (IsInOptions) {
            MainMenu.SetActive(true);
            OptionsMenu.SetActive(false);
            IsInOptions = false;
        } else {
            OptionsMenu.SetActive(true);
            MainMenu.SetActive(false);
            IsInOptions = true;
        }
    }
}

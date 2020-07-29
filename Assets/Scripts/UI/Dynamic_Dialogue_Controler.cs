using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Dynamic_Dialogue_Controler : MonoBehaviour {

    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject dialogPrefab;
    [SerializeField] private GameObject choicePrefab;
    [SerializeField] private TextAssetValue dialogValue;
    [SerializeField] private GameObject dialogHolder;
    [SerializeField] private GameObject choiceHolder;
    [SerializeField] private ScrollRect dialogScroll;
    [SerializeField] private Story story;

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnEnable() {
        setStory();
        RefreshView();
    }

    public void setStory() {
        if (dialogValue.value) {
            DeleteOldDialogs();
            story = new Story(dialogValue.value.text);
        } else {
            Debug.LogError("Failed to set Story");
        }
    }

    void DeleteOldDialogs() {
        for (int i = 0; i< dialogHolder.transform.childCount; i++) {
            Destroy(dialogHolder.transform.GetChild(i).gameObject);
        }
    }

    public void RefreshView() {
        while (story.canContinue) {
            makeNewDialog(story.Continue());
            CreateChoices();
        }
        if (Input.anyKeyDown) {
            canvas.SetActive(false);

        }
        StartCoroutine(ScrollCo());
    }

    IEnumerator ScrollCo() {
        yield return null;
        dialogScroll.verticalNormalizedPosition = 0f;
    }

    void makeNewDialog(string dialog) {
        DynamicDialogObject newDialog = Instantiate(dialogPrefab, dialogHolder.transform).GetComponent<DynamicDialogObject>();
        newDialog.Setup(dialog);
    }

    void makeNewResponce(string responce, int choiceValue) {
        DynamicDialogButton newButton = Instantiate(choicePrefab, choiceHolder.transform).GetComponent<DynamicDialogButton>();
        newButton.Setup(responce, choiceValue);
        Button responceButton = newButton.gameObject.GetComponent<Button>();
        if (responceButton) {
            responceButton.onClick.AddListener(delegate { ChooseChoice(choiceValue); });
        }
    }

    void CreateChoices() {
        for (int i = 0; i < choiceHolder.transform.childCount; i++) {
            Destroy(choiceHolder.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < story.currentChoices.Count; i++) {
            makeNewResponce(story.currentChoices[i].text, i);
        }
    }

    void ChooseChoice(int choice) {
        story.ChooseChoiceIndex(choice);
        RefreshView();
    }
}

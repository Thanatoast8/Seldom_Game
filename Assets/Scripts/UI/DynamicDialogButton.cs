using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicDialogButton : MonoBehaviour
{


    [SerializeField] private Text text;
    [SerializeField] private int choiceValue;

    public void Setup(string newDialog, int choice) {
        text.text = newDialog;
        choiceValue = choice;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

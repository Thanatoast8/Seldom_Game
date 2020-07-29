using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicDialogObject : MonoBehaviour
{

    [SerializeField] private Text text;

    public void Setup(string newDialog) {
        text.text = newDialog;
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

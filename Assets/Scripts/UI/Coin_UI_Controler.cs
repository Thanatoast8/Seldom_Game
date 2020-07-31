using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_UI_Controler : MonoBehaviour
{
    [SerializeField] private Text coinCount;
    [SerializeField] private Inventory inventory;
    // Update is called once per frame
    void Update()
    {
        coinCount.text = inventory.coin.ToString();
    }
}

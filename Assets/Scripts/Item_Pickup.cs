using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pickup : MonoBehaviour
{
    public Item item;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            PickUp();
        }
    }
    void PickUp() {
        bool wasPicekcUp = Inventory.instance.Add(item);
        if (wasPicekcUp) {
            Destroy(gameObject);
        }
    }
}

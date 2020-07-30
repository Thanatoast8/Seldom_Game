using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pickup : MonoBehaviour
{
    public Item item;

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Collision Detected");
        if (collision.CompareTag("Player")) {
            PickUp();
        }
    }
    void PickUp() {
        Debug.Log("Picked up " + item.name);
        bool wasPicekcUp = Inventory.instance.Add(item);
        if (wasPicekcUp) {
            Destroy(gameObject);
        }
    }
}

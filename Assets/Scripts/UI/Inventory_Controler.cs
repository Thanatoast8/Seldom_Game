using UnityEngine;

public class Inventory_Controler : MonoBehaviour
{
    Inventory inventory;

    public Transform inventoryParent;
    public GameObject InventoryUI;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.OnItemChangedCallback += UpdateUI;

        slots = inventoryParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory")) {
            InventoryUI.SetActive(!InventoryUI.activeSelf);
        }
    }

    void UpdateUI() {
        for (int i = 0; i <slots.Length; i++) {
            if (i < inventory.items.Count) {
                slots[i].AddItem(inventory.items[i]);
            } else {
                slots[i].ClearSlot();
            }
        }
    }

}

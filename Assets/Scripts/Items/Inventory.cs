using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton

    public static Inventory instance;

    private void Awake() {
        if (instance != null) {
            Debug.LogWarning("Inventory Instance already exists, attempted to create new instance.");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;


    public int space = 18;
    public int coin = 0;


    public List<Item> items = new List<Item>();

    public bool Add(Item item) {
        if (!item.isDefaultItem) {
            if (items.Count >= space) {
                Debug.Log("Not Enough Room");
                return false; ;
            }
            items.Add(item);
            if (OnItemChangedCallback != null) {
                OnItemChangedCallback.Invoke();
            }
        }
        return true;
    }

    public void Remove(Item item) {
        items.Remove(item);
        if (OnItemChangedCallback != null) {
            OnItemChangedCallback.Invoke();
        }
    }
}

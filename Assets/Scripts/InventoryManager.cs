using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<int> inventorySlots = new List<int>();

    public Sprite[] keys;

    private void Start()
    {
        UpdateInventory();
    }

    public void UpdateInventory()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            if (inventorySlots[i] != -1)
            {
                transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = keys[inventorySlots[i]];
            }
            else
            {
                transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = null;
            }
        }
        
    }
    public void AddItem(int id, GameObject item)
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (inventorySlots[i] == -1)
            {
                Destroy(item);
                inventorySlots[i] = id;
                UpdateInventory();
                return;
            }
        }
    }
}

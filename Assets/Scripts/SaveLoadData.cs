using UnityEngine;

public class SaveLoadData : MonoBehaviour
{    
    private InventoryManager inventoryManager;

    private void Awake()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        if (PlayerPrefs.HasKey("InventoryItem1"))
        {
            LoadingData();
        }
    }
    public void SavingData()
    {
        for (int i = 0; i < inventoryManager.inventorySlots.Count; i++)
        {
            PlayerPrefs.SetInt("InventoryItem" + i.ToString(), inventoryManager.inventorySlots[i]);
        }
    }
    public void LoadingData()
    {
        for (int i = 0; i < inventoryManager.inventorySlots.Count; i++)
        {
            inventoryManager.inventorySlots[i] = PlayerPrefs.GetInt("InventoryItem" + i.ToString());
        }
    }
    public void DeleteKey()
    {
        PlayerPrefs.DeleteAll();
    }
}

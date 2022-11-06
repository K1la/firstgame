using UnityEngine;
using UnityEngine.UI;

public class KeyConnector : MonoBehaviour
{
    public int state = 0;
    [SerializeField] private int needKeyId = 0;
    [SerializeField] private GameObject button;
    [SerializeField] private Sprite hasKey;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && state == 0)
        {
            for (int i = 0; i < FindObjectOfType<InventoryManager>().inventorySlots.Count; i++)
            {
                if (FindObjectOfType<InventoryManager>().inventorySlots[i] == needKeyId)
                {
                    Button connectButton = button.GetComponent<Button>();
                    connectButton.onClick.RemoveAllListeners();
                    connectButton.onClick.AddListener(this.ConnectKey);
                    LeanTween.moveX(button.GetComponent<RectTransform>(), 120, 0.4f);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        LeanTween.moveX(button.GetComponent<RectTransform>(), 400, 0.3f);
    }
    public void ConnectKey()
    {
        for (int i = 0; i < FindObjectOfType<InventoryManager>().inventorySlots.Count; i++)
        {
            if (FindObjectOfType<InventoryManager>().inventorySlots[i] == needKeyId)
            {
                state = 1;
                FindObjectOfType<InventoryManager>().inventorySlots[i] = -1;
                FindObjectOfType<InventoryManager>().UpdateInventory();
                LeanTween.moveX(button.GetComponent<RectTransform>(), 400, 0.3f);
                GetComponent<SpriteRenderer>().sprite = hasKey;
            }
        }
    }
}
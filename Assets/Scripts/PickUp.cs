using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private int id;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<InventoryManager>().AddItem(id, gameObject);
        }
    }
}

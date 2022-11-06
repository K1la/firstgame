using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    [SerializeField] private List<KeyConnector> keyConnectors;
    [SerializeField] private Sprite hasKeys;

    private void Update()
    {
        for (int i = 0; i < keyConnectors.Count; i++)
        {
            if (keyConnectors[i].state == 0)
            {
                return;
            }
        }
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = hasKeys;
        GetComponent<CircleCollider2D>().enabled = true;
    }    
}

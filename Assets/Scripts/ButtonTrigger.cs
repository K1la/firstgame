using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField] private GameObject switchSceneButton;
    [SerializeField] private string sceneName;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {            
            LeanTween.moveX(switchSceneButton.GetComponent<RectTransform>(), 120, 0.4f);
            FindObjectOfType<UiManager>().sceneName = sceneName;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        LeanTween.moveX(switchSceneButton.GetComponent<RectTransform>(), 400, 0.3f);
    }
}

using UnityEngine;

public class DialogButton : MonoBehaviour
{
    [SerializeField] private GameObject dialogButton;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            LeanTween.moveX(dialogButton.GetComponent<RectTransform>(), 120, 0.4f);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        LeanTween.moveX(dialogButton.GetComponent<RectTransform>(), 400, 0.3f);
    }
    public void EndStartButton()
    {
        LeanTween.moveX(dialogButton.GetComponent<RectTransform>(), 400, 0.3f);
    }
}

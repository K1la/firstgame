using UnityEngine;
using UnityEngine.SceneManagement;

public class GoblinScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

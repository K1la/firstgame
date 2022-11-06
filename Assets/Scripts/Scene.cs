using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void NextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

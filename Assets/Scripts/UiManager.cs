using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public string sceneName;

    [SerializeField] private int hearts = 2;
    [SerializeField] private Sprite heartFull;
    [SerializeField] private Sprite heartEmpty;
    [SerializeField] private Transform heartsPanel;

    [SerializeField] private CanvasGroup fadePanel;

    [SerializeField] private SaveLoadData saver;

    public void NextScene()
    {
        LeanTween.alphaCanvas(fadePanel, 1, 0.3f).setOnComplete(SwitchScene);
    }
    public void SwitchScene()
    {
        saver.SavingData();
        SceneManager.LoadScene(sceneName);
    }
    public void UpdateHearts(int subCount)
    {
        hearts -= subCount;
        if (hearts<=0)
        {
            RestartLevel();
        }
        for (int i = 0; i < heartsPanel.childCount; i++)
        {
            heartsPanel.GetChild(i).GetComponent<Image>().sprite = heartEmpty;
        }
        for (int i = 0; i < hearts; i++)
        {
            heartsPanel.GetChild(i).GetComponent<Image>().sprite = heartFull;
        }
    }
    public void RestartLevel()
    {
        int sceneID = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneID);
    }

}

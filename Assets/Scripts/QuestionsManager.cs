using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionsManager : MonoBehaviour
{
    [SerializeField] private QuestionsList[] questions;
    [SerializeField] private Text[] answersText;
    [SerializeField] private Text qText;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject dialButton;
    [SerializeField] private GameObject[] answButtons;

    List<object> qList;
    QuestionsList crntQ;
    int randQ;
    
    public void StartTest()
    {
        LeanTween.moveX(startButton.GetComponent<RectTransform>(), 120, 0.3f);
    }
    public void OnClickPlay()
    {
        print("started");
        qList = new List<object>(questions);
        QuestionGenerate();
        StartDialoge();
        LeanTween.moveX(startButton.GetComponent<RectTransform>(), 400, 0.3f);
        FindObjectOfType<PlayerMovement>().moveSpeed = 0f;
    }
    void QuestionGenerate()
    {
        if (qList.Count > 0)
        {
            randQ = Random.Range(0, qList.Count);
            crntQ = qList[randQ] as QuestionsList;
            qText.text = crntQ.question;
            List<string> answers = new List<string>(crntQ.answers);
            for (int i = 0; i < crntQ.answers.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                answersText[i].text = answers[rand];
                answers.RemoveAt(rand);
            }
        }
        else
        {
            print("вы прошли 1 уровень");
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void AnswersButton(int index)
    {
        if (answersText[index].text.ToString() == crntQ.answers[0]) print("true answer");
        else
        {            
            FindObjectOfType<UiManager>().UpdateHearts(1);
        }

        qList.RemoveAt(randQ);
        QuestionGenerate();
    }
    public void StartDialoge()
    {
        LeanTween.moveX(dialButton.GetComponent<RectTransform>(), 120, 0.4f);
        for (int i = 0; i < answButtons.Length; i++)
        {            
            LeanTween.moveX(answButtons[i].GetComponent<RectTransform>(), 120, 0.4f);
            System.Threading.Thread.Sleep(10);
        }
    }
}
[System.Serializable]
public class QuestionsList
{
    public string question;
    public string[] answers = new string[3];
}

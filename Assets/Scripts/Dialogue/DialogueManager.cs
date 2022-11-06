using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;

    [SerializeField] private GameObject key;
    [SerializeField] private int id;
    private string scene;

    public Animator anim;

    private Queue<string> sentences;

    void Start()
    {
        scene = SceneManager.GetActiveScene().name;
        sentences = new Queue<string>();
        if (PlayerPrefs.HasKey(scene))
        {
            id = PlayerPrefs.GetInt(scene);
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        FindObjectOfType<PlayerMovement>().moveSpeed = 0f;
        anim.SetBool("IsOpen", true);           

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            FindObjectOfType<QuestionsManager>().StartTest();
            return;
        }
        string sentence = sentences.Dequeue();

        dialogueText.text = sentence;
    }
    public void EndDialogue()
    {
        if (id != -1)
        {            
            FindObjectOfType<InventoryManager>().AddItem(id, key);
            PlayerPrefs.SetInt(scene, -1);
            id = -1;
        }
        FindObjectOfType<PlayerMovement>().moveSpeed = 5f;
        anim.SetBool("IsOpen", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Dialog dialogue;
    Queue<string> sentences;
    public GameObject dialogPanel;
    public TextMeshProUGUI displayText;
    string activeSentence;
    public float typingpeed;
    AudioSource myAudio;
    public AudioClip speakSound;

    public void Start()
    {
        sentences = new Queue<string>();
        myAudio = GetComponent<AudioSource>();
    }
    void StartDialogue()
    {
        sentences.Clear();
        foreach (string sentence in dialogue.sentenceList)
        {
            sentences.Enqueue(sentence);
        }
        displayNextSentence();
    }

    void displayNextSentence()
    {
        string nombre;
        nombre = gameObject.name;
        Debug.Log("Sentences count " + sentences.Count +" NOMBRE: " +nombre);
        if (sentences.Count <= 0)
        {
            displayText.text = activeSentence;
            Debug.Log("Menor que cero");
            return;
        }
        activeSentence = sentences.Dequeue();
        displayText.text = activeSentence;
        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(activeSentence));
    }
    int cont;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogPanel.SetActive(true);
            StartDialogue();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && displayText.text == activeSentence)
            {
                displayNextSentence();
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogPanel.SetActive(false);
            StopAllCoroutines();
        }
    }
    IEnumerator TypeTheSentence(string sentence)
    {
        displayText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            displayText.text += letter;
            yield return new WaitForSeconds(typingpeed);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue_Manager : MonoBehaviour
{
    public Dialogue dialogue;
    Queue<string> sentences;
    public GameObject DialoguePanel;
    string activeSentence;
    public float typingSpeed;
    public TextMeshProUGUI displayText;
    AudioSource myAudio;
    public AudioClip speakSound;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void StartDialogue()
    {
        sentences.Clear();
        foreach(string sentence in dialogue.sentenceList)
        {
            
            //toma la oración y la agrega a la cola, para despues ser presentada
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    void DisplayNextSentence()
    {
        if(sentences.Count <= 0)
        {
            displayText.text = activeSentence;
            return;
        }

        activeSentence = sentences.Dequeue();
        displayText.text = activeSentence;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("Player"))
        {
            DialoguePanel.SetActive(true);
            StartDialogue();
            Debug.Log("Colision Inicial");
        }  
    }

    private void OnTriggerStay2D(Collider2D other)
    {
       
           if (Input.GetKeyDown(KeyCode.E) & other.CompareTag("Player"))
                {
                    DisplayNextSentence();
                    Debug.Log("Colision Jugador");
                }
        
    }

    private void OnTriggerExit2D(Collider2D salida)
    {
        if (salida.CompareTag("Player"))
        {
            DialoguePanel.SetActive(false);
            Debug.Log("Adios");
        }
    }
}

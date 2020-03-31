using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManagerCut : MonoBehaviour
{
    // Start is called before the first frame update
    
    Queue<string> sentences;
    string activeSentence;
    AudioSource myAudio;
    
    public Dialog dialogue;
    public GameObject dialogPanel;
    public TextMeshProUGUI displayText;
    public AudioClip speakSound;
    public GameObject Dialogo1, Dialogo2, Cutscene;
    public float typingpeed;

    public bool Texto1, Texto2, Texto3;


    public void Start()
    {
        sentences = new Queue<string>();
        myAudio = GetComponent<AudioSource>();
        Texto1 = true;
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
        Debug.Log("Sentences count " + sentences.Count);
        if (sentences.Count <= 0)
        {
            displayText.text = activeSentence;
            Texto1 = false;
            Cutscene.SetActive(true);
            Dialogo1.SetActive(false);
            return;
        }
        activeSentence = sentences.Dequeue();
        displayText.text = activeSentence;
        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(activeSentence));

    }
    private void FixedUpdate()
    {

            if (Texto1 == true)
            {
                dialogPanel.SetActive(true);
                StartDialogue();
                if (Input.GetKeyDown(KeyCode.E) && displayText.text == activeSentence)
                {

                    displayNextSentence();
                }

            }
            else
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
            Debug.Log("Display " + displayText.text);
            yield return new WaitForSeconds(typingpeed);
        }

    }
}


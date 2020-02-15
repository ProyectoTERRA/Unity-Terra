using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Dialogues_Interaction : MonoBehaviour
{

    public Dialogue dialogue;
    public GameObject clip;
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
        foreach (string sentence in dialogue.sentenceList)
        {

            //toma la oración y la agrega a la cola, para despues ser presentada
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    void DisplayNextSentence()
    {
        if (sentences.Count <= 0)
        {
            displayText.text = activeSentence;
            return;
        }

        activeSentence = sentences.Dequeue();
        displayText.text = activeSentence;

        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(activeSentence));
    }

    IEnumerator TypeTheSentence(string sentence)
    {
        displayText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            displayText.text += letter;
            myAudio.PlayOneShot(speakSound);
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D coli)
    {

        if (coli.CompareTag("PlayerInteractionZone"))
        {
            DialoguePanel.SetActive(true);
            StartDialogue();
            transform.localScale = new Vector3(-1.8f, 1.8f, 1f);
            Debug.Log("Colision Inicial");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("PlayerInteractionZone"))
        {
            if (Input.GetKeyDown(KeyCode.E) && displayText.text == activeSentence)
            {
                DisplayNextSentence();
                Debug.Log("Colision Jugador");
            }
        }
    }


    private void OnTriggerExit2D(Collider2D salida)
    {
        if (salida.CompareTag("PlayerInteractionZone"))
        {
            DialoguePanel.SetActive(false);
            StopAllCoroutines();
            Debug.Log("Adios");
        }
    }

}

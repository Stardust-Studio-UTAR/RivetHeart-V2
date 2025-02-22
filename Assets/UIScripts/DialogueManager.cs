﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    //for typewriter
    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";


    public Button CloseButton;
    public Button DialoguePanel;
    public Button InteractionText;

    //for interaction text
    public GameObject interactionText;
    public GameObject dialoguebox;

    ///[SerializeField]
    private bool openDialogue;
    private bool interactTextAppear;

    //for next dialogue
    public GameObject[] Dialogue;
    int index;

    private bool canInteract = false;
    //Coroutine coroutine;

    void Start()
    {
        //StartCoroutine(ShowText()); //for typewriter

        //interactionText.SetActive(false); //for interaction text

        dialoguebox.SetActive(true);
        openDialogue = false;
        interactTextAppear = false;

        //Play from the top
        index = 0;
    }


    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            if (!interactTextAppear)
            {
                //PlayerManager.instance.SetPlayerState(PlayerState.PAUSED);
                interactTextAppear = true;
                openDialogue = true;
                DisplayDialoguePanel();
            }
            else
            {
                //PlayerManager.instance.SetPlayerState(PlayerState.ALIVE);
                interactTextAppear = false;
                openDialogue = false;
                HideDialoguePanel();
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            index += 1;

            for (int i = 0; i < Dialogue.Length; i++)
            {
                Dialogue[i].gameObject.SetActive(false);
                Dialogue[index].gameObject.SetActive(true);
            }

            Debug.Log(index);
        }
        #region not used
        //if (index >= 10)
        //    index = 10;

        //if (index < 0)
        //    index = 0;



        //if (index == 0)
        //{
        //    Dialogue[0].gameObject.SetActive(true);
        //}

        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    index -= 1;

        //    for (int i = 0; i < Dialogue.Length; i++)
        //    {
        //        Dialogue[i].gameObject.SetActive(false);
        //        Dialogue[index].gameObject.SetActive(true);
        //    }
        //    Debug.Log(index);
        //}
        #endregion
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }


    public void ButtonCloseButton()    //Close dialogue
    {
        HideDialoguePanel();
    }


    public void DisplayDialoguePanel()
    {
        DialoguePanel.gameObject.SetActive(true);
        //coroutine = StartCoroutine(ShowText());
        //index = 0;
        Dialogue[index].gameObject.SetActive(true);
    }

    public void HideDialoguePanel()
    {
        index = 0;
        for (int i = 0; i < Dialogue.Length; i++)
        {
            Dialogue[i].gameObject.SetActive(false);
        }
        DialoguePanel.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            canInteract = true;
            interactionText.SetActive(true);
            //index = 0;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            interactTextAppear = false;
            interactionText.SetActive(false);
            //DialoguePanel.gameObject.SetActive(false);
            HideDialoguePanel();        
            //StopCoroutine(coroutine);
        }
    }
}
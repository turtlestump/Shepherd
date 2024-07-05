using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Extra imports: UI will allow us to access the dialogue panel, and the text library is TextMeshPro
using UnityEngine.UI;
using TMPro;

public class NPCDialogue : MonoBehaviour {

    // Variables
    public GameObject dialoguePanel;    // Used to access dialoguePanel
    public TMP_Text dialogueText;       // Will contain the desired text.

    public string[] dialogue;
    private int index;

    public float wordSpeed;             // Will contain the speed at which words are printed.
    public bool playerInRange;          // Will check to see if player is within the collision box.

    public GameObject continueButton;   // Used to access continue button.

    void Start() {

        resetText();

    }

    // Update is called once per frame
    void Update() {
        
        // Check if player is in range and if they are pressing the interact key.
        if (Input.GetKeyDown(KeyCode.E) && playerInRange) {
            
            // Check if dialogue panel is active.
            if (dialoguePanel.activeInHierarchy) {

                resetText();

            }
            else {

                dialoguePanel.SetActive(true);

                // Begin writing effect
                StartCoroutine(Writing());

            }

        }

        if (dialogueText.text == dialogue[index]) {

            continueButton.SetActive(true);

        }

    }

    // This method will be called when the dialogue needs to be reset.
    public void resetText() {

        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);

    }

    // This will create the "writing" effect as words are written to the dialogue panel.
    IEnumerator Writing() {

        foreach(char letter in dialogue[index].ToCharArray()) {

            // Increment written text by one character.
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);

        }

    }

    // This method will allow overflowing messages to move to the next line.
    public void NextLine() {

        continueButton.SetActive(false);

        if (index < dialogue.Length - 1) {

            index++;
            dialogueText.text = "";
            StartCoroutine(Writing());

        }
        else {

            resetText();

        }

    }

    // This method will be called when the player enters the trigger range.
    private void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Player")) {

            playerInRange = true;

        }

    }

    // This method will be called when the player exits the trigger range.
    private void OnTriggerExit2D(Collider2D other) {

        if (other.CompareTag("Player")) {

            playerInRange = false;
            resetText();

        }

    }

}

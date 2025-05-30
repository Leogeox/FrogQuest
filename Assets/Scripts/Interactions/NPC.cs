using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI speakerName;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Image portraitImage;

    [SerializeField] private string[] Name;
    [SerializeField] private string[] dialogueWords;
    [SerializeField] private Sprite[] portrait;

    private bool playerisClose;
    private int index;
    public GameObject contBtn;
    public float wordSpeed;
    AudioManager audioManager;

    [SerializeField] private GrabbingTongue tongue;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && playerisClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                if (index < Name.Length && index < dialogueWords.Length && index < portrait.Length)
                {
                    speakerName.text = Name[index];
                    dialogueText.text = string.Empty; // Clear text before typing
                    portraitImage.sprite = portrait[index];
                    tongue.enabled = false; 
                    // audioManager.PlaySFX(audioManager.NPCtalk);
                    StartCoroutine(Typing());
                }
            }
        }
    }

    public void zeroText()
    {
        if (index >= Name.Length || index >= dialogueWords.Length)
        {
            dialoguePanel.SetActive(false);
            contBtn.SetActive(false);
            tongue.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerisClose = true;
        }
    }

    IEnumerator Typing()
    {
        contBtn.SetActive(false);
        foreach (char letter in dialogueWords[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        contBtn.SetActive(true); 
    }

    public void NextLine()
    {
        contBtn.SetActive(false);

        if (index < dialogueWords.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            speakerName.text = Name[index];
            portraitImage.sprite = portrait[index];
            tongue.enabled = false;
            // audioManager.PlaySFX(audioManager.NPCtalk);
            contBtn.SetActive(true);
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
            dialoguePanel.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            dialoguePanel.SetActive(false);
            playerisClose = false;
            tongue.enabled = true;
            zeroText();
        }
    }
}

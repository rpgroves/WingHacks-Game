using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
public class DialogueController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameplate;
    [SerializeField] TextMeshProUGUI text;
    public Image portrait;
    public Image background;
    [SerializeField] float textSpeed = 1.0f;
    [SerializeField] GameObject dialogueOptions;
    [SerializeField] TextMeshProUGUI button1Text;
    [SerializeField] TextMeshProUGUI button2Text;
    [SerializeField] TextMeshProUGUI button3Text;
    public TLDialogue dialogue;
    int index = 0;
    List<string> lines;
    bool isChoice = false;

    public static DialogueController Instance { get; private set; }
    void Awake()
    {
        int numDialogueController = FindObjectsOfType<DialogueController>().Length;
        if(numDialogueController > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }
    }

    void Start()
    {
        dialogueOptions.gameObject.SetActive(false);
    }

    void Update()
    {
        if(isChoice)
            return;
        if(Input.GetMouseButtonDown(0))
        {
            if(text.text == lines[index])
            {
                index++;
                NextParagraph();
            }
            else
            {
                StopAllCoroutines();
                text.text = lines[index];
            }
        }
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextParagraph()
    {
        if(index < lines.Count)
        {
            text.text = "";
            StartCoroutine(TypeLine());
        }
        else
        {
            GameManager.Instance.IncrementTimeline();
        }
    }

    public void StartNewDialogue(TLDialogue newDialogue)
    {
        isChoice = false;
        dialogueOptions.gameObject.SetActive(false);
        nameplate.text = dialogue.speaker;

        text.text = "";
        dialogue = newDialogue;
        lines = dialogue.lines;
        index = 0;
        NextParagraph();
    }

    public void StartNewDialogueChoice(TLDialogueChoice newDialogueChoice)
    {
        isChoice = true;
        dialogueOptions.gameObject.SetActive(true);
        button1Text.text = newDialogueChoice.option1;
        button2Text.text = newDialogueChoice.option2;
        button3Text.text = newDialogueChoice.option3;
    }

    public void ChooseDialogue(int optionChosen)
    {
        Debug.Log("There has been a choice.");
        dialogueOptions.gameObject.SetActive(false);
        GameManager.Instance.IncrementTimeline();
    }
}

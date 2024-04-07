using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
public class DialogueController : MonoBehaviour
{
    GameManager gm;
    [SerializeField] TextMeshProUGUI nameplate;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Image portrait;
    [SerializeField] float textSpeed = 1.0f;
    [SerializeField] GameObject dialogueOptions;
    [SerializeField] TextMeshProUGUI button1Text;
    [SerializeField] TextMeshProUGUI button2Text;
    [SerializeField] TextMeshProUGUI button3Text;
    public TLDialogue dialogue;
    int index = 0;
    List<string> lines;

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
        gm = GameManager.Instance;
        dialogueOptions.gameObject.SetActive(false);
        nameplate.text = dialogue.speaker;
        lines = dialogue.lines;
        NextParagraph();
    }

    void Update()
    {
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
            // end dialogue
        }
    }

    public void StartNewDialogue(TLDialogue newDialogue)
    {
        text.text = "";
        dialogue = newDialogue;
        lines = dialogue.lines;
        NextParagraph();
    }

    public void StartNewDialogueOption(TLDialogueOption newDialogueOption)
    {
        dialogueOptions.gameObject.SetActive(true);
        button1Text.text = newDialogueOption.option1;
        button2Text.text = newDialogueOption.option2;
        button3Text.text = newDialogueOption.option3;
    }

    public void ChooseDialogue(int optionChosen)
    {

    }
}

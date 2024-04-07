using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<ScriptableObject> timeline;
    DialogueController dialogueController;
    public static GameManager Instance { get; private set; }
    int index = 0;
    Timeline currentTimelineEvent;
    void Awake()
    {
        int numGameManagers = FindObjectsOfType<GameManager>().Length;
        if(numGameManagers > 1)
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
        dialogueController = DialogueController.Instance;
        dialogueController.gameObject.SetActive(false);

        currentTimelineEvent = timeline[index] as Timeline;
        HandleTimeline();
    }
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void IncrementTimeline()
    {
        index++;
        if(!(index < timeline.Count))
        {
            Debug.Log("End of timeline, warning");
            return;
        }
        currentTimelineEvent = timeline[index] as Timeline;
        HandleTimeline();
    }

    private void HandleTimeline()
    {
        string type = currentTimelineEvent.GetTimelineType();

        if(type == "dialogue")
            HandleDialogue();
        if(type == "dialogue choice")
            HandleDialogueChoice();
        if(type == "change ui")
            HandleChangeUI();
        if(type == "change scene")
        {
            LoadScene((currentTimelineEvent as TLChangeScene).sceneIndex);
        }
    }

    private void HandleDialogue()
    {
        dialogueController.gameObject.SetActive(true);
        dialogueController.StartNewDialogue(currentTimelineEvent as TLDialogue);
    }
    private void HandleDialogueChoice()
    {
        dialogueController.gameObject.SetActive(true);
        dialogueController.StartNewDialogueChoice(currentTimelineEvent as TLDialogueChoice);
    }
    private void HandleChangeUI()
    {
        Sprite portrait = (currentTimelineEvent as TLChangeUI).portrait;
        Sprite background = (currentTimelineEvent as TLChangeUI).background;

        if(portrait != null)
        {
            dialogueController.portrait.gameObject.SetActive(true);
            dialogueController.portrait.sprite = portrait;
        }
        else
        {
            dialogueController.portrait.gameObject.SetActive(false);
        }
        if(background != null)
        {
            dialogueController.background.gameObject.SetActive(true);
            dialogueController.background.sprite = background;
        }
        else
        {
            dialogueController.background.gameObject.SetActive(false);
        }
        IncrementTimeline();
    }
}

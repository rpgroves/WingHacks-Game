using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    List<Timeline> timeline;
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

        currentTimelineEvent = timeline[index];
    }
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void IncrementTimeline()
    {
        index++;
        currentTimelineEvent = timeline[index];
    }

    private void HandleDialogue()
    {
        dialogueController.gameObject.SetActive(true);
        dialogueController.StartNewDialogue(currentTimelineEvent as TLDialogue);
    }
    private void HandleDialogueChoice()
    {

    }
    private void HandleChangeUI()
    {

    }
}

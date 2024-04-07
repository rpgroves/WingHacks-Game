using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogueChoice")]
public class TLDialogueChoice : ScriptableObject
{
public string option1;
public string option2;
public string option3;

public int option1Score = 1;
public int option2Score = 0;
public int option3Score = -1;

}

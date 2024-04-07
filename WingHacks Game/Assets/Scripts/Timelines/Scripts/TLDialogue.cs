using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue")]
public class TLDialogue : ScriptableObject, Timeline
{
public string speaker;
public List<string> lines;

public string GetTimelineType()
{
    return "dialogue";
}

}

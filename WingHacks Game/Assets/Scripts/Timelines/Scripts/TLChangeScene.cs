using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ChangeScene")]
public class TLChangeScene : ScriptableObject, Timeline
{
    public int sceneIndex = 0;
    public string GetTimelineType()
    {
        return "change scene";
    }
}

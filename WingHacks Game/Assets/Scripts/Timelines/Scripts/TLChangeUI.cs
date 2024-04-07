using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ChangeUI")]
public class TLChangeUI : ScriptableObject, Timeline
{
    public Sprite portrait = null;
    public Sprite background = null;
    public string GetTimelineType()
    {
        return "change ui";
    }
}

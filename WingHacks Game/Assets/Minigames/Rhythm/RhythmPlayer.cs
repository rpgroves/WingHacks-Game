using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
using TMPro;

public class RhythmPlayer : MonoBehaviour
{
    [SerializeField] GameObject greenBox;
    [SerializeField] GameObject blueBox;
    [SerializeField] GameObject orangeBox;
    [SerializeField] GameObject pinkBox;
    [SerializeField] GameManager_Rhythm gm;
    [SerializeField] int pointsPerBlock;
    
    private void OnA()
    {
        HandleInput(greenBox);
    }
    private void OnS()
    {
        HandleInput(blueBox);
    }
    private void OnD()
    {
        HandleInput(orangeBox);
    }
    private void OnF()
    {
        HandleInput(pinkBox);
    }

    private void OnReset()
    {
        gm.GameReset();
    }

    private void HandleInput(GameObject boxUsed)
    {
        if(gm.gameOngoing == false)
        {
            gm.GameStart();
            return;
        }

        RaycastHit2D[] scanHits = Physics2D.BoxCastAll(boxUsed.transform.position, Vector3.one, 0.0f, Vector2.up, 1.0f);

        if(scanHits != null)
        {
            GameObject hitObj = null;

            foreach(RaycastHit2D rh in scanHits)
            {
                Debug.Log(rh.transform.gameObject.name);
                if(rh.transform.gameObject.tag == "Note")
                {
                    hitObj = rh.transform.gameObject;
                    break;
                }
            }

            if(hitObj == null)
                return;

            float distance = Vector3.Distance(hitObj.transform.position, boxUsed.transform.position);
            gm.IncrementScore((int)(distance * pointsPerBlock));
            
            Destroy(hitObj);
        }
    }
}

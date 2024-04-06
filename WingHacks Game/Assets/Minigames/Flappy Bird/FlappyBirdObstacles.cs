using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdObstacles : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    bool isMoving = false;

    private void Update()
    {
        if(isMoving)
            this.transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    public void ToggleSpeed(bool b)
    {
        isMoving = b;
    }
}

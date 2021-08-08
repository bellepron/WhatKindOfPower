using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    void LateUpdate()
    {
        if (Globals.isGameActive && !Globals.isGameFinished)
        {
            transform.position += new Vector3(0, 0, InputHandler.Instance.runSpeed * Time.deltaTime);
            transform.position = new Vector3(InputHandler.Instance.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    float mouseSpeed = 10;
    float mouseY = 0;
    float mouseX = 0;
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * Time.deltaTime * 20.0f;
        mouseY += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSpeed;

        mouseX = Mathf.Clamp(mouseX, -90.0f, 90.0f);
        mouseY = Mathf.Clamp(mouseY, -55.0f, 55.0f);
        //Mathf.Clamp(현재위치, 제한하는 최소값, 최대값) : 회전 제한 주기위한
        transform.localEulerAngles = new Vector3(-mouseY, mouseX, 0);

    }
}

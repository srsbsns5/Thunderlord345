using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float senstivity = 100f;
    public Transform playerTrans;
    public string player = "P1";
    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X " + player) * senstivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y " + player) * senstivity * Time.deltaTime;

        playerTrans.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }
}

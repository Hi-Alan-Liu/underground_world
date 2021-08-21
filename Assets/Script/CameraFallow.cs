using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    public float camerMoveSpeed = 120.0f;
    public GameObject cameraFollowObj;
    public float clampAngle = 80.0f; // 可見角度
    public float inputSensitivity = 150.0f; // 敏感度
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputZ;
    private float rotY = 0.0f;
    private float rotX = 0.0f;


    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        // 自建的 input
        // float inputX = Input.GetAxis("RightStickHorizontal");
        // float inputZ = Input.GetAxis("RightStickVertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        // finalInputX = inputX + mouseX;
        // finalInputZ = inputZ + mouseY;
        finalInputX = mouseX;
        finalInputZ = mouseY;

         rotY += finalInputX * inputSensitivity * Time.deltaTime;
        rotX += finalInputZ * inputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp ( rotX, -clampAngle, clampAngle); // 數學題

        // Debug.Log(rotX);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }

    void LateUpdate()
    {
        CameraUpdate();
    }

    void CameraUpdate()
    {
        Transform target = cameraFollowObj.transform;

        float step = camerMoveSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}

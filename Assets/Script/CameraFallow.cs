using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    public GameObject cameraFollowObj;
    [Header("鏡頭左右移動速度")]
    [Range(0,180)]
    public float camerMoveSpeed = 120.0f;
    [Header("滑鼠上下角度")]
    [Range(0,180)]
    public float clampAngle = 80.0f; // 可見角度
    [Header("滑鼠靈敏度")]
    [Range(0,180)]
    public float inputSensitivity = 150.0f; // 靈敏度
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

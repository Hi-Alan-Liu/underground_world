using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    public float speed = 1.0f;
    void Update()
    {
        transform.Translate(Vector3.forward * speed, Space.Self);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeController : MonoBehaviour
{
    public float radian = 0;
    public float perRadian = 0.5f;
    public float radius = 1f;

    public bool is_x = true;
    public bool is_y = true;
    Vector3 starPosition;
    // Start is called before the first frame update
    void Start()
    {
        starPosition = transform.position; //儲存預設位置
    }

    // Update is called once per frame
    void Update()
    {
        radian += perRadian;
        float dy = Mathf.Cos(radian);
        Debug.Log("漂浮數值:" + dy);

        float x = is_x ? dy : 0;
        float y = is_y ? dy : 0;
        transform.position = starPosition + new Vector3(x, y , 0);
    }
}

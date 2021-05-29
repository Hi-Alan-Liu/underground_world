using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] array = {99,88,77,66};

        //foreach.ex
        foreach (var item in array)
        {
            Debug.Log("foreach:" + item.ToString());
        }
    
    
    
    
    //for迴圈
    //for(int i = 0; i<3; i ++) {
    Debug.Log("array 長度:" + array.Length);
    for(int i = 0; i< array.Length; i ++){
        Debug.Log("基本for迴圈:" + array[i]);
    }


    int cupsInTheSink = 5;
    while (cupsInTheSink > 0)
    {
        Debug.Log("while :" + cupsInTheSink);
        cupsInTheSink = cupsInTheSink - 1;
    }

    
    //list範例
    List<int> list = new List<int>();
    list.Add(99);
    list.Add(88);
    list.Add(77);
    list.Add(66);

    foreach (var item in list)
    {
        Debug.Log("list foreach:" + item.ToString());
    }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

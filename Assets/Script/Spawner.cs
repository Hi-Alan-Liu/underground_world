using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefab = new GameObject[2];
    public int time;
    public bool status;
    [Header("生成怪物位置")]
    [Range(-10,10)]
    public int x_min , x_max;
    [Header("生成怪物位置")]
    [Range(-10,10)]
    public int z_min , z_max;
    public int prefabCount;
    public int prefabMaxCount;
    private Transform initTransform;
    // Start is called before the first frame update
    void Start()
    {
        initTransform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        checkedPrefabCount();
        if (status || prefabCount >= prefabMaxCount)
        {
            return;
        }

        //生成怪物
        float x =initTransform.position.x + Random.Range(x_min,x_max);
        float y =transform.position.y;
        float z =initTransform.position.z + Random.Range(z_min,z_max);
        Vector3 position = new Vector3(x,y,z);
        int randomNumber = Random.Range(0,prefab.Length);
        Instantiate(prefab[randomNumber], position, Quaternion.identity);
        status = true;
        Invoke("Reset",time);
    }
    void checkedPrefabCount()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Skeleton");

        prefabCount = gos.Length;
    }
    void Reset()
    {
        status = false;
    }
}

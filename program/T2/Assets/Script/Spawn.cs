using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public float time = 3f ;
    public Transform[] point;
    public int max;
    public int count;
    private List<GameObject> spawnedList = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("Create", time, time);
    }
    void Create(){
        if (count >= max)
        {
            return;
        }
        count++;

        int i = Random.Range(0, point.Length);
        GameObject obj = Instantiate(prefab, point[i].position, point[i].rotation);
        spawnedList.Add(obj);

        /*
        int i = Random.Range(0, points.Length);
        Instantiate(prefab, points[i]);
        */
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = spawnedList.Count - 1; i >= 0; i--)
        {
            if (spawnedList[i] == null)
            {
                spawnedList.RemoveAt(i);
                count--;
            }
        }
    }
}

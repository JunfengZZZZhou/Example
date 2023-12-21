using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject planePrefab;//飞机预制体
    public Transform[] startPoints;//出生点
    public float timeInterval = 1;//出生间隔
    private float currentTime = 0;//计时器
    private bool start = false;//是否开始
    public void spawnStart()
    {
        start = true;
    }
    public void spawnStop()
    {
        start = false;
    }
    void Update()
    {
        if (start == false)
        {
            return;
        }
        currentTime += Time.deltaTime;
        if (currentTime > timeInterval)
        {
            currentTime = 0;
            int index = Mathf.FloorToInt(Random.Range(0, startPoints.Length - 0.001f));//出生点序号
            GameObject plane = Instantiate(planePrefab, startPoints[index].position,
                Quaternion.Euler(0, Random.Range(0, 180), 0));//出生飞机
            Destroy(plane, 5);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject planePrefab;//�ɻ�Ԥ����
    public Transform[] startPoints;//������
    public float timeInterval = 1;//�������
    private float currentTime = 0;//��ʱ��
    private bool start = false;//�Ƿ�ʼ
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
            int index = Mathf.FloorToInt(Random.Range(0, startPoints.Length - 0.001f));//���������
            GameObject plane = Instantiate(planePrefab, startPoints[index].position,
                Quaternion.Euler(0, Random.Range(0, 180), 0));//�����ɻ�
            Destroy(plane, 5);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;//����
    public TMP_Text scoreText;//�������
    public void AddScore(int score2add)
    {
        score += score2add;//�ӷ�
        scoreText.text = "Score: " + score;//��ʾ����
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

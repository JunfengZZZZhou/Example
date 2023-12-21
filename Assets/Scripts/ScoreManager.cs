using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;//分数
    public TMP_Text scoreText;//分数面板
    public void AddScore(int score2add)
    {
        score += score2add;//加分
        scoreText.text = "Score: " + score;//显示分数
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

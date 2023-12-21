using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float maxHealth = 100;//总血量
    private float currentHealth;//当前血量
    public GameObject smokePrefab;//烟的预制体
    private GameObject mySmoke;//飞机身上的烟
    void Start()
    {
        currentHealth = maxHealth;//设置一开始满血
    }
    public void GetHit(float damage)
    {
        if(currentHealth < 0)
        {
            return;
        }
        currentHealth -= damage;//血量变少
        if (mySmoke == null)
        {
            mySmoke = Instantiate(smokePrefab, transform);//生成烟
        }  
        if (currentHealth < 0)
        {
            Debug.Log("死亡");//飞机死了
            Die();
        }
    }
    public GameObject explosionPrefab;//爆炸预制体
    public AudioSource explosionSound;//爆炸声音
    public int score = 10;//打爆这个飞机加的分数
    private void Die()
    {
        Destroy(Instantiate(explosionPrefab, transform.position, transform.rotation), 2);//在飞机的位置生成一个爆炸,2秒后摧毁
        Destroy(Instantiate(explosionSound, transform.position, transform.rotation), 2);//在飞机的位置生成一个爆炸声音,2秒后摧毁
        Destroy(gameObject);//销毁飞机
        FindObjectOfType<ScoreManager>().AddScore(score);//加分
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

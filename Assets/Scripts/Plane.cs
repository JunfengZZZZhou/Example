using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float maxHealth = 100;//��Ѫ��
    private float currentHealth;//��ǰѪ��
    public GameObject smokePrefab;//�̵�Ԥ����
    private GameObject mySmoke;//�ɻ����ϵ���
    void Start()
    {
        currentHealth = maxHealth;//����һ��ʼ��Ѫ
    }
    public void GetHit(float damage)
    {
        if(currentHealth < 0)
        {
            return;
        }
        currentHealth -= damage;//Ѫ������
        if (mySmoke == null)
        {
            mySmoke = Instantiate(smokePrefab, transform);//������
        }  
        if (currentHealth < 0)
        {
            Debug.Log("����");//�ɻ�����
            Die();
        }
    }
    public GameObject explosionPrefab;//��ըԤ����
    public AudioSource explosionSound;//��ը����
    public int score = 10;//������ɻ��ӵķ���
    private void Die()
    {
        Destroy(Instantiate(explosionPrefab, transform.position, transform.rotation), 2);//�ڷɻ���λ������һ����ը,2���ݻ�
        Destroy(Instantiate(explosionSound, transform.position, transform.rotation), 2);//�ڷɻ���λ������һ����ը����,2���ݻ�
        Destroy(gameObject);//���ٷɻ�
        FindObjectOfType<ScoreManager>().AddScore(score);//�ӷ�
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

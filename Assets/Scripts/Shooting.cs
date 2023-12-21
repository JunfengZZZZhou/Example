using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject laser;//����
    public AudioSource laserSound;//��������
    public LineRenderer laserBeam;//����
    public float DPS = 100;//ÿ���˺�ֵ
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//��������һ��
        {
            laser.SetActive(true);//��������
            laserSound.Play();//���ⷢ����������
        }
        else if (Input.GetMouseButtonUp(0))//̧������һ��
        {
            laser.SetActive(false);//������ʧ
            laserSound.Stop();//���ⷢ������ֹͣ
        }
        else if (Input.GetMouseButton(0))//��������ʱ��
        {
            Debug.DrawRay(laser.transform.position, laserBeam.transform.forward, Color.green);
            RaycastHit hit;
            if (Physics.Raycast(laser.transform.position, laserBeam.transform.forward, out hit))
            {
                //Debug.Log(hit.collider.name);//��ӡ����������
                laserBeam.SetPosition(1, laserBeam.transform.InverseTransformPoint(hit.point));//�������߶˵�
                if (hit.collider.GetComponent<Plane>() != null)
                {
                    hit.collider.GetComponent<Plane>().GetHit(DPS * Time.deltaTime);//����ɻ�
                }
            }
            else
            {
                laserBeam.SetPosition(1, new Vector3(0, 0, 1));//û�д򵽶�����Ϊԭ��
            }
        }
    }
}

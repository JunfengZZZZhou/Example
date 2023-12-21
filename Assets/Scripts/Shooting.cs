using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject laser;//激光
    public AudioSource laserSound;//激光声音
    public LineRenderer laserBeam;//射线
    public float DPS = 100;//每秒伤害值
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//按下鼠标的一刻
        {
            laser.SetActive(true);//激光显现
            laserSound.Play();//激光发射声音播放
        }
        else if (Input.GetMouseButtonUp(0))//抬起鼠标的一刻
        {
            laser.SetActive(false);//激光消失
            laserSound.Stop();//激光发射声音停止
        }
        else if (Input.GetMouseButton(0))//按着鼠标的时候
        {
            Debug.DrawRay(laser.transform.position, laserBeam.transform.forward, Color.green);
            RaycastHit hit;
            if (Physics.Raycast(laser.transform.position, laserBeam.transform.forward, out hit))
            {
                //Debug.Log(hit.collider.name);//打印碰到的物体
                laserBeam.SetPosition(1, laserBeam.transform.InverseTransformPoint(hit.point));//设置射线端点
                if (hit.collider.GetComponent<Plane>() != null)
                {
                    hit.collider.GetComponent<Plane>().GetHit(DPS * Time.deltaTime);//打击飞机
                }
            }
            else
            {
                laserBeam.SetPosition(1, new Vector3(0, 0, 1));//没有打到东西则为原长
            }
        }
    }
}

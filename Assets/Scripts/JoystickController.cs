using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//1、限制移动范围
//2、获得摇杆位置
public class JoystickController : ScrollRect
{
    private float radius;//半径
    public Vector3 contentPosition = new Vector3(0, 0, 0);//摇杆位置

    protected override void Start()
    {
        base.Start();
        radius = (transform as RectTransform).sizeDelta.x * 0.3f;
    }
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        contentPosition = content.anchoredPosition;//摇杆距离中心的位置
        if (contentPosition.magnitude > radius)
        {
            contentPosition = contentPosition.normalized * radius;//设置contentPosition为边缘位置
            SetContentAnchoredPosition(contentPosition);//设置摇杆在边缘位置
        }
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        contentPosition = new Vector3(0, 0, 0);
    }
}

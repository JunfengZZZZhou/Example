using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//1�������ƶ���Χ
//2�����ҡ��λ��
public class JoystickController : ScrollRect
{
    private float radius;//�뾶
    public Vector3 contentPosition = new Vector3(0, 0, 0);//ҡ��λ��

    protected override void Start()
    {
        base.Start();
        radius = (transform as RectTransform).sizeDelta.x * 0.3f;
    }
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        contentPosition = content.anchoredPosition;//ҡ�˾������ĵ�λ��
        if (contentPosition.magnitude > radius)
        {
            contentPosition = contentPosition.normalized * radius;//����contentPositionΪ��Եλ��
            SetContentAnchoredPosition(contentPosition);//����ҡ���ڱ�Եλ��
        }
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        contentPosition = new Vector3(0, 0, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonControl : MonoBehaviour
{
    public VirtualButtonBehaviour button;//���ⰴť
    private Vector3 originalPosition;//С����ԭʼλ��
    public GameObject car;//С��
    private void OnButtonDown(VirtualButtonBehaviour button)
    {
        car.transform.position = originalPosition;//���ع�ԭʼλ��
    }
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = car.transform.position;//��¼����ԭʼλ��
        button.RegisterOnButtonPressed(OnButtonDown);
    }
    private void OnDestroy()
    {
        button.UnregisterOnButtonPressed(OnButtonDown);
    }
}

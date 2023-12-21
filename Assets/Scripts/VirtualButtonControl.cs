using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonControl : MonoBehaviour
{
    public VirtualButtonBehaviour button;//虚拟按钮
    private Vector3 originalPosition;//小车的原始位置
    public GameObject car;//小车
    private void OnButtonDown(VirtualButtonBehaviour button)
    {
        car.transform.position = originalPosition;//车回归原始位置
    }
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = car.transform.position;//记录车的原始位置
        button.RegisterOnButtonPressed(OnButtonDown);
    }
    private void OnDestroy()
    {
        button.UnregisterOnButtonPressed(OnButtonDown);
    }
}

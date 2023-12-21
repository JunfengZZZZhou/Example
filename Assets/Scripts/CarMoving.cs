using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoving : MonoBehaviour
{
    public JoystickController controller;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        if (controller.contentPosition.magnitude != 0)
        {
            Vector3 direction = new Vector3(controller.contentPosition.x, 0, controller.contentPosition.y);
            transform.localRotation = Quaternion.LookRotation(direction);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}

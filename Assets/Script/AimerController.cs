using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimerController : MonoBehaviour
{
    private Joystick joystick;
    private float rangeX = 7.5f;
    private float rangeYUp = 5.5f;
    private float rangeYDown = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        JoystickBound();
    }

    private void JoystickBound()
    {
        transform.Translate(joystick.Horizontal * 0.15f, joystick.Vertical * 0.15f, 0f);
        if (transform.position.x > rangeX)
        {
            transform.position = new Vector3(rangeX, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -rangeX)
        {
            transform.position = new Vector3(-rangeX, transform.position.y, transform.position.z);
        }
        if (transform.position.y < rangeYDown)
        {
            transform.position = new Vector3(transform.position.x, rangeYDown, transform.position.z);
        }
        if (transform.position.y > rangeYUp)
        {
            transform.position = new Vector3(transform.position.x, rangeYUp, transform.position.z);
        }
    }
}

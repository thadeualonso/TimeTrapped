using UnityEngine;
using System.Collections;

public class InputManager : Singleton<InputManager> {

    public float horizontal;
    public float vertical;

    public bool btnA, btnX;

    public bool keyboard, joystick;

    void Update()
    {

        ChecarControle();

        if (joystick)
        {
            horizontal = Input.GetAxisRaw("LeftJoystickX");
            vertical = Input.GetAxisRaw("LeftJoystickY");
        }
    
        if (keyboard)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            btnA = Input.GetButton("A");
            btnX = Input.GetButton("X");
        }

    }

    void ChecarControle()
    {
        if (Input.GetJoystickNames().Length != 0 && Input.GetJoystickNames()[0] == "Controller (Xbox One For Windows)")
        {
            joystick = true;
            keyboard = false;
        }
        else
        {
            keyboard = true;
            joystick = false;
        }
    }

}

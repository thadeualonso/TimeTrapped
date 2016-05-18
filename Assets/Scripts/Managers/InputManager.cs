using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    static InputManager instance = null;

    public float horizontal;
    public float vertical;

    public bool btnA, btnX;

    public bool keyboard, joystick;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Duplicated input manager self-destructing");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

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
        if (Input.GetJoystickNames()[0] == "Controller (Xbox One For Windows)")
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

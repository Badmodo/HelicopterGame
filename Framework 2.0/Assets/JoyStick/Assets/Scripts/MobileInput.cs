using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    private static MobileInput mobileInput = null;
    private static bool Initialised => mobileInput != null;

    public static void Initialise()
    {
        // If the mobile input is already initialised, throw an InvalidOperationException
        if(Initialised)
            throw new System.InvalidOperationException("Mobile Input already initialised!");

        // Load the Mobile Input prefab and Instantiate it
        MobileInput input = Resources.Load<MobileInput>("Mobile Input Prefab");
        mobileInput = Instantiate(input);
        
        // Change the instantiated objects name and make it not be destroyed
        mobileInput.gameObject.name = "Mobile Input";
        DontDestroyOnLoad(mobileInput.gameObject);
    }

    public static float GetJoystickAxis(JoystickAxis _axis)
    {
        // If the mobile input isn't initialised, throw a NullReferenceException
        if(!Initialised)
            throw new System.NullReferenceException("Mobile Input not initialised.");

        // If the joystick input module isn't set, throw a NullReferenceException
        if(mobileInput.joystickInput == null)
            throw new System.NullReferenceException("Joystick Input not initialised.");

        // Switch on the passed axis and return the appropriate value
        switch(_axis)
        {
            case JoystickAxis.Horizontal: return mobileInput.joystickInput.Axis.x * 5;
            case JoystickAxis.Vertical: return mobileInput.joystickInput.Axis.y * 5;
            default: return 0;
        }
    }

    [SerializeField]
    private JoystickInput joystickInput;
    [SerializeField]
    private GyroInput gyroInput;
}

/*
*Joystick used for movement
*mouseJoystick used for camera rotation
*Buttons for actions
*This script should be attached with mobile canvas
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : MonoBehaviour
{
    #region Variables
    public Joystick joystick;
    public Joystick mouseJoystick;

    [Range(0.1f,5f)]public float joystickSensitivity = 1f;
    [HideInInspector] public float inputX = 0.0f;
    [HideInInspector] public float inputY = 0.0f;

    [Range(0.1f,5f)]public float mouseJoystickSensitivity = 1f;
    [HideInInspector] public float mouseX = 0.0f;
    [HideInInspector] public float mouseY = 0.0f;

    [HideInInspector] public bool fire = false;
    [HideInInspector] public bool aim = false;
    [HideInInspector] public bool jump = false;
    [HideInInspector] public bool crouch = false;
    [HideInInspector] public bool sprint = false;
    [HideInInspector] public bool  Q = false;
    [HideInInspector] public bool reload = false;
    [HideInInspector] public bool changeWeapon = false;

    #endregion

    void Start()
    {
        if(joystick == null)
        {
            Debug.LogError("Player control Fixed Joystick not found");
        }
        if(mouseJoystick == null)
        {
            Debug.LogError("Mouse control dynamic Joystick not found");
        }
    }

    void Update()
    {
        inputX = joystick.Horizontal * joystickSensitivity;
        inputY = joystick.Vertical * joystickSensitivity;

        mouseX = mouseJoystick.Horizontal * mouseJoystickSensitivity;
        mouseY = mouseJoystick.Vertical * mouseJoystickSensitivity;
    }
    
    #region methods
    public void JumpIn()
    {
        jump = true;
    }

    public void JumpOut()
    {
        jump = false;
    }

    public void CrouchIn()
    {
        crouch = true;
    }

    public void CrouchOut()
    {
        crouch = false;
    }

    public void SprintIn()
    {
        sprint = true;
    }

    public void SprintOut()
    {
        sprint = false;
    }

    public void QIn()
    {
        Q = true;
    }

    public void QOut()
    {
        Q = false;
    }

    public void ReloadIn()
    {
        reload = true;
    }

    public void ReloadOut()
    {
        reload = false;
    }

    public void FireIn()
    {
        fire = true;
    }

    public void FireOut()
    {
        fire = false;
    }

    public void Aim()
    {
        aim = !aim;
    }

    

    public void ChangeWeaponIn()
    {
        changeWeapon = true;
    }

    public void ChangeWeaponOut()
    {
        changeWeapon = false;
    }

    #endregion

}

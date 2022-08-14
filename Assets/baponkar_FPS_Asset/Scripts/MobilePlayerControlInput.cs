using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace Baponkar.FPS
{
    public class MobilePlayerControlInput : MonoBehaviour
    {
        bool jumpInput;
        float horizontalInput;
        float verticalInput;
        bool fireInput;
        int  activeWeaponIndex;

        public Joystick joystick;
        public Joystick mousejoystick;

        PlayerControlInput playerControlInput;

        // Start is called before the first frame update
        void Start()
        {
            playerControlInput = GetComponent<PlayerControlInput>();
        }

        // Update is called once per frame
        void Update()
        {
            playerControlInput.jumpInput = jumpInput;
            playerControlInput.fireInput = fireInput;

            playerControlInput.activeWeaponIndex = activeWeaponIndex;

            playerControlInput.horizontalInput = joystick.Horizontal;
            playerControlInput.verticalInput = joystick.Vertical;
            
            playerControlInput.mouseX = mousejoystick.Horizontal;
            playerControlInput.mouseY = mousejoystick.Vertical * 2f;
        }

        public void JumpIn()
        {
            jumpInput = true;
        }
        public void JumpOut()
        {
            jumpInput = false;
        }

        public void FireIn()
        {
            fireInput = true;
        }
        public void FireOut()
        {
            fireInput = false;
        }

        public void Move(float horizontal, float vertical)
        {
            horizontalInput = horizontal;
            verticalInput = vertical;
        }

        public void ChangeWeapon(int index)
        {
            activeWeaponIndex = index;
        }


    }
}

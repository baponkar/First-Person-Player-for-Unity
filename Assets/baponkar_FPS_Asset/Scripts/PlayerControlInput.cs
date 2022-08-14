using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Baponkar.FPS
    {
    public class PlayerControlInput : MonoBehaviour
    {
        public KeyCode jumpKey = KeyCode.Space;
        public bool jumpInput;
        public float horizontalInput;
        public float verticalInput;
        public KeyCode [] keycodes;
        public bool fireInput;
        public float mouseScrollWheel;

        public float mouseX;
        public float mouseY;

        public int  activeWeaponIndex;
        // Start is called before the first frame update
        void Start()
        {
            keycodes = new KeyCode[6];
            keycodes[0] = KeyCode.Alpha1;
            keycodes[1] = KeyCode.Alpha2;
            keycodes[2] = KeyCode.Alpha3;
            keycodes[3] = KeyCode.Alpha4;
            keycodes[4] = KeyCode.Alpha5;
            keycodes[5] = KeyCode.Alpha6;
        }

        // Update is called once per framek
        void Update()
        {
            //for pc decomment the following lines
            // mouseX = Input.GetAxis("Mouse X");
            // mouseY = Input.GetAxis("Mouse Y");

            // jumpInput = Input.GetKeyDown(jumpKey);
            // fireInput = Input.GetButtonDown("Fire1");
            // horizontalInput = Input.GetAxis("Horizontal");
            // verticalInput = Input.GetAxis("Vertical");
            // mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");

            // for(int i =0; i< keycodes.Length; i++)
            // {
            //     if(Input.GetKeyDown(keycodes[i]))
            //     {
            //         activeWeaponIndex = i;
            //     }
            // }
            
        }
    }
}

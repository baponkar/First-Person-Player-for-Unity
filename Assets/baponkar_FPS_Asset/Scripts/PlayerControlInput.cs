using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Baponkar.FPS
{
    public class PlayerControlInput : MonoBehaviour
    {
        #region Variables

        public KeyCode jumpKey = KeyCode.Space;
        [HideInInspector] public bool jumpInput;
        [HideInInspector] public float horizontalInput;
        [HideInInspector] public float verticalInput;
        public KeyCode [] keycodes;
        [HideInInspector] public bool fireInput;
        [HideInInspector] public float mouseScrollWheel;

        [HideInInspector] public float mouseX;
        [HideInInspector] public float mouseY;

        [HideInInspector] public int  activeWeaponIndex;

        [Header("Weapon Input control by mobile or pc")]
        public bool mobileInput;

        #endregion
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

            if(!mobileInput)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            
        }

        // Update is called once per framek
        void Update()
        {
            if(mobileInput)
            {
                MobileInput();
            }
            else
            {
                PCInput();
            }
            
        }

        void PCInput()
        {
            //for pc decomment the following lines
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");

            jumpInput = Input.GetKeyDown(jumpKey);
            fireInput = Input.GetButtonDown("Fire1");
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");

            for(int i =0; i< keycodes.Length; i++)
            {
                if(Input.GetKeyDown(keycodes[i]))
                {
                    activeWeaponIndex = i;
                }
            }
        }

        void MobileInput()
        {
            
        }
    }
}

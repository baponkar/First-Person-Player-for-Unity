using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baponkar.FPS
{
    [RequireComponent(typeof(Camera))]
    [RequireComponent(typeof(AudioListener))]
    public class MouseLook : MonoBehaviour
    {
        #region Variables
        public Transform playerBody;
        float mouseSensitivity= 100f;
        float xRotation;

        PlayerControlInput playerControlInput;
        #endregion

        void Awake()
        {
            
        }

        void Start()
        {
            playerControlInput = GetComponentInParent<PlayerControlInput>();
            //Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            
            float mouseX = playerControlInput.mouseX * mouseSensitivity * Time.deltaTime;
            float mouseY = playerControlInput.mouseY * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}

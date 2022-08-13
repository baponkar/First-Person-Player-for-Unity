using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baponkar.FPS
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables
        public float speed = 12f;
        public float gravity = -9.81f;
        public KeyCode jumpKey = KeyCode.Space;
        public float jumpHeight = 3f;
        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;
        public float pushPower = 2.0F;
        [HideInInspector]public Vector3 movement;
        [HideInInspector]public bool isGrounded;
        [HideInInspector]public bool isJumping;

        Vector3 velocity;
        CharacterController controller;
        Animator animator;

        public bool jumpUp
        {
            get{return isJumping;}
            set
            {
                if(isJumping != value)
                {
                    isJumping = value;
                    // Run some function or event here
                }
            }
        }
        #endregion

        
        void Start()
        {
            controller = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
        }

        
        void Update()
        {
            GroundCheck();
            Jump();
            MoveMent(); 
        }

        void Jump()
        {
            isJumping = !isGrounded;
            if(Input.GetKeyDown(jumpKey) && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        void GroundCheck()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
        }

        void MoveMent()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            movement = transform.right * x + transform.forward * z;
            controller.Move(movement * Time.deltaTime * speed);
            velocity += (Vector3.up * gravity) * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
            animator.SetFloat("Speed", Mathf.Clamp(movement.magnitude,0,1f));
        }

        void OnDrawGizmos()
        {
            // Draws a 1 unit long red line in front of the object
            Gizmos.color = Color.red;
            Vector3 pos = new Vector3(transform.position.x-.1f,transform.position.y +1.8f,transform.position.z+0.2f);
            Vector3 pos1 = new Vector3(transform.position.x-.1f,transform.position.y +1.8f,transform.position.z+0.2f);
            Vector3 pos2 = new Vector3(transform.position.x,transform.position.y +1.8f,transform.position.z+0.2f);
            Vector3 pos3 = new Vector3(transform.position.x+.1f,transform.position.y +1.8f,transform.position.z+0.2f);
            Vector3 pos4 = new Vector3(transform.position.x+.1f,transform.position.y +1.8f,transform.position.z+0.2f);
            Vector3 direction = transform.TransformDirection(Vector3.forward) * .6f;
            Gizmos.DrawRay(pos, direction);
            Gizmos.DrawRay(pos1, direction);
            Gizmos.DrawRay(pos2, direction);
            Gizmos.DrawRay(pos3, direction);
            Gizmos.DrawRay(pos4, direction);
        }

        void OnControllerColliderHit(ControllerColliderHit hit)
        {
            Rigidbody body = hit.collider.attachedRigidbody;

            // no rigidbody
            if (body == null || body.isKinematic)
                return;

            // We dont want to push objects below us
            if (hit.moveDirection.y < -0.3f)
                return;

            // Calculate push direction from move direction,
            // we only push objects to the sides never up and down
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

            // If you know how fast your character is trying to move,
            // then you can also multiply the push velocity by that.

            // Apply the push
            body.velocity = pushDir * pushPower;
        }

    }
}

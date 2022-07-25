using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baponkar.FPS
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayerFootStep : MonoBehaviour
    {
        #region Variables
        AudioSource audioSource;
        PlayerMovement playerMovement;
        public AudioClip[] footSteps;
        public AudioClip jumpClip;
        bool jump;
        #endregion

        
        void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
            audioSource = GetComponent<AudioSource>();
        }

        
        void Update()
        {
            if(playerMovement.movement.magnitude > 0 && playerMovement.isGrounded)
            {
                audioSource.clip = footSteps[Random.Range(0, footSteps.Length)];
                if(!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
        }
    }
}

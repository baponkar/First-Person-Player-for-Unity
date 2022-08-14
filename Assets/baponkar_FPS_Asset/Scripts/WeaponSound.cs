using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Baponkar.FPS
{
    public class WeaponSound : MonoBehaviour
    {
        CharacterFightControl fightControl;
        AudioSource audioSource;

        PlayerControlInput playerControlInput;

        public AudioClip[] audioClips;

        
        void Start()
        {
            fightControl = GetComponentInParent<CharacterFightControl>(); 
            audioSource = GetComponent<AudioSource>(); 
            playerControlInput = GetComponentInParent<PlayerControlInput>();
        }

        
        void Update()
        {
            if (fightControl.hasWeapon && playerControlInput.fireInput && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
            }
        }
    }
}

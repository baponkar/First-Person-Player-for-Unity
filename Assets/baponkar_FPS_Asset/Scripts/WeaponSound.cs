using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Baponkar.FPS
{
    public class WeaponSound : MonoBehaviour
    {
        CharacterFightControl fightControl;
        AudioSource audioSource;

        public AudioClip[] audioClips;

        
        void Start()
        {
            fightControl = GetComponentInParent<CharacterFightControl>(); 
            audioSource = GetComponent<AudioSource>(); 
        }

        
        void Update()
        {
            if (fightControl.hasWeapon && Input.GetButtonDown("Fire1"))
            {
                audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baponkar.FPS
{
    public class CharacterFightControl : MonoBehaviour
    {
        Animator animator;
        public GameObject [] weapons;
        

        public bool hasWeapon;
        int WeaponNumber = 0;
        int currentWeapon = 0;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            bool fire = Input.GetButtonDown("Fire1");
            if(hasWeapon)
            {
                animator.SetBool("hasWeapon", true);
                WeaponSwitch();
                WeaponAttack(fire);
            }
            else
            {
                animator.SetBool("hasWeapon", false);
                Punch(fire);
            }
            
        }

        void WeaponAttack(bool input)
        {
             if(input)
            {
                if(Random.Range(0,1f) > 0.5f)
                {
                    animator.SetBool("swing01", true);
                }
                else
                {
                    animator.SetBool("swing02", true);
                }
            }
            else
            {
                animator.SetBool("swing01", false);
                animator.SetBool("swing02", false);
            }
        }

        void Punch(bool input)
        {
            if(input)
            {
                if(Random.Range(0,1f) > 0.5f)
                {
                    animator.SetBool("punchRight", true);
                }
                else
                {
                    animator.SetBool("punchLeft", true);
                }
            }
            else
            {
                animator.SetBool("punchLeft", false);
                animator.SetBool("punchRight", false);
            }
        }

        void WeaponSwitch()
        {
            
            if(Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                if(Input.GetAxis("Mouse ScrollWheel") > 0)
                {
                    WeaponNumber = (WeaponNumber + 1);
                }
                if(Input.GetAxis("Mouse ScrollWheel") < 0)
                {
                    WeaponNumber = (WeaponNumber - 1);
                }
            }
            if(WeaponNumber >= weapons.Length)
            {
                WeaponNumber = 0;
            }
            if(WeaponNumber < 0)
            {
                WeaponNumber = weapons.Length -1;
            }
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                WeaponNumber = 0;
            }
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                WeaponNumber = 1;
            }
            if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                WeaponNumber = 2;
            }
            if(Input.GetKeyDown(KeyCode.Alpha4))
            {
                WeaponNumber = 3;
            }
            if(currentWeapon != WeaponNumber)
            {
                for(int i=0;i<weapons.Length;i++)
                {
                    if(i==WeaponNumber)
                    {
                        weapons[i].SetActive(true);
                    }
                    else
                    {
                        weapons[i].SetActive(false);
                    }
                }
                currentWeapon = WeaponNumber;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Baponkar.FPS
{
    public class CharacterFightControl : MonoBehaviour
    {
        Animator animator;
        public Weapon [] weapons;
        public Text text;
        public KeyCode [] keycodes;
        public bool hasWeapon;
        public int WeaponNumber = 0;
        public int currentWeapon = 0;

        void Start()
        {
            animator = GetComponent<Animator>();
            //weapons = GetComponentsInChildren<Weapon>();
            //keycodes = new KeyCode[weapons.Length];
            for(int i = 0; i < weapons.Length; i++)
            {
                keycodes[i] = (KeyCode) System.Enum.Parse(typeof(KeyCode), "Alpha" + (i + 1));
            }
            
        }

        void Update()
        {
            bool fire = Input.GetButtonDown("Fire1");

            if(hasWeapon)
            {
                ActivateWeapon(WeaponNumber);
                animator.SetBool("hasWeapon", true);
                WeaponSwitch();
                WeaponAttack(fire);
            }
            else
            {
                animator.SetBool("hasWeapon", false);
                DeActivateWeapon();
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
        void DeActivateWeapon()
        {
            for(int i=0;i<weapons.Length;i++)
            {
                weapons[i].gameObject.SetActive(false);
            }
        }

        void ActivateWeapon(int weaponIndex)
        {
            text.text = "Equiped Weapon: " + weapons[weaponIndex].gameObject.name.ToString();
            if(currentWeapon != weaponIndex)
            {
                for(int i = 0; i < weapons.Length; i++)
                {
                    if(i==weaponIndex)
                    {
                        weapons[weaponIndex].gameObject.SetActive(true);
                        text.text = "Equiped Weapon: " + weapons[i].gameObject.name.ToString();
                    }
                    else
                    {
                        weapons[i].gameObject.SetActive(false);
                    }
                }
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
            
           

            for(int i=0; i<keycodes.Length; i++)
            {
                if(Input.GetKeyDown(keycodes[i]))
                {
                    WeaponNumber = i;
                }
            }
        }
    }
}

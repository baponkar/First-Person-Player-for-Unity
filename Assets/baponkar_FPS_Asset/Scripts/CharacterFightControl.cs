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
        [HideInInspector]public Text text;
        
        public bool hasWeapon;
        public int WeaponNumber = 0;
        public int currentWeapon = 0;
        [HideInInspector]public PlayerControlInput playerControlInput;

        void Start()
        {
            animator = GetComponent<Animator>();
            playerControlInput = GetComponent<PlayerControlInput>();
        }

        void Update()
        {
            bool fire = playerControlInput.fireInput;

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
            if(playerControlInput.mouseScrollWheel != 0)
            {
                if(playerControlInput.mouseScrollWheel > 0)
                {
                    WeaponNumber = (WeaponNumber + 1);
                }
                if(playerControlInput.mouseScrollWheel < 0)
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
            
           
            WeaponNumber = playerControlInput.activeWeaponIndex;

           
        }
    }
}

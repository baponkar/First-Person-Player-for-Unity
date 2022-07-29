using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponType
    {
        Mace = 0,
        Sword = 1,
        Axe = 2,
        Knife = 3,
        Sickle = 4,
        Machete = 5
    }
    public WeaponType weaponType;

    void Start()
    {
        weaponType = new WeaponType();
    }
}

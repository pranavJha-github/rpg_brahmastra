using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlazeWeaponHandler : MonoBehaviour
{
    [SerializeField] private GameObject weaponLogic;

    public void EnableWeapon(AnimationEvent myEvent)
    {
        //Debug.Log(myEvent.floatParameter);
        //Debug.Log(myEvent.stringParameter);
        //Debug.Log(myEvent.intParameter);
        
        weaponLogic.TryGetComponent<WeaponDamage>(out WeaponDamage weaponDamage);
        weaponDamage!.SetAttack(myEvent.intParameter);
        weaponLogic.SetActive(true);
    }

    public void DisableWeapon()
    {
        weaponLogic.SetActive(false);
    }
}

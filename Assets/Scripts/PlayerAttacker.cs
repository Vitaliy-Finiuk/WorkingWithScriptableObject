using System.Collections;
using System.Collections.Generic;
using DS5;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    private AnimationHandler _animationHandler;

    private void Awake()
    {
        _animationHandler = GetComponentInChildren<AnimationHandler>();
    }
    
    public void HandleLightAttack(WeaponItem weaponItem)
    {
        
    }
}

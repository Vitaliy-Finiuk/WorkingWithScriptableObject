using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS5
{
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
}
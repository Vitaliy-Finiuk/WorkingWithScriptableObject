using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS5
{
    public class WeaponSlotManager : MonoBehaviour
    {
        private WeaponHolderSlot _leftHandSlot;
        private WeaponHolderSlot _rightHandSlot;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            
            WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
            foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
            {
                if (weaponSlot.IsLeftHandSlot)
                {
                    _leftHandSlot = weaponSlot;
                }else if (weaponSlot.IsRightHandSlot)
                {
                    _rightHandSlot = weaponSlot;
                }
            }
        }

        public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
        {
            if (isLeft)
            {
                _leftHandSlot.LoadWeaponModel(weaponItem);

                #region Handle Left Weapon Idle Animations

                

                #endregion
                
                if (weaponItem != null)
                {
                    _animator.CrossFade(weaponItem.Left_hand_idle, 0.2f);
                }
                else
                {
                    _animator.CrossFade("Left Arm Empty", 0.2f);
                }
            }
            else
            {
                _rightHandSlot.LoadWeaponModel(weaponItem);

                #region Handle Right Weapon Idle Animations

                if (weaponItem != null)
                {
                    _animator.CrossFade(weaponItem.Right_hand_idle, 0.2f);
                }
                else
                {
                    _animator.CrossFade("Right Arm Empty", 0.2f);
                }

                #endregion

            }
            
        }
    }
}

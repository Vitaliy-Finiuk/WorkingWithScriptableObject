using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS5
{
    public class WeaponSlotManager : MonoBehaviour
    {
        private WeaponHolderSlot _leftHandSlot;
        private WeaponHolderSlot _rightHandSlot;

        private void Awake()
        {
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
            }
            else
            {
                _rightHandSlot.LoadWeaponModel(weaponItem);
            }
            
        }
    }
}

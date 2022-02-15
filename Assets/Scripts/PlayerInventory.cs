using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DS5
{
    public class PlayerInventory : MonoBehaviour
    {
        private WeaponSlotManager _weaponSlotManager;
        
        [SerializeField] private WeaponItem _rightWeapon;
        [SerializeField] private WeaponItem _leftWeapon;

        private void Awake()
        {
            _weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
        }

        private void Start()
        {
            _weaponSlotManager.LoadWeaponOnSlot(_rightWeapon, false);
            _weaponSlotManager.LoadWeaponOnSlot(_leftWeapon, true);
        }
    }
}
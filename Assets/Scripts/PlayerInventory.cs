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

        [SerializeField] private WeaponItem _unarmedWeapon;

        [SerializeField] private WeaponItem[] _weaponsInRightHandSlots = new WeaponItem[1];
        [SerializeField] private WeaponItem[] _weaponsInLeftHandSlots = new WeaponItem[1];

        [SerializeField] private int _currentRightWeaponIndex = -1;
        [SerializeField] private int _currentLeftWeaponIndex = -1;
        
        private void Awake()
        {
            _weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
        }

        private void Start()
        {
            _rightWeapon = _unarmedWeapon;
            _leftWeapon = _unarmedWeapon;
        }

        public void ChangeInRightHandWeapon()
        {
            _currentRightWeaponIndex = _currentRightWeaponIndex + 1;

            if (_currentRightWeaponIndex == 0 && _weaponsInRightHandSlots[0] != null)
            {
                _rightWeapon = _weaponsInRightHandSlots[_currentRightWeaponIndex];
                _weaponSlotManager.LoadWeaponOnSlot(_weaponsInRightHandSlots[_currentRightWeaponIndex], false);
            }
            else if(_currentRightWeaponIndex == 0 && _weaponsInRightHandSlots[0] == null)
            {
                _currentRightWeaponIndex = _currentRightWeaponIndex + 1;
            }

            else if (_currentRightWeaponIndex == 1 && _weaponsInRightHandSlots[1] != null)
            {
                _rightWeapon = _weaponsInRightHandSlots[_currentRightWeaponIndex];
                _weaponSlotManager.LoadWeaponOnSlot(_weaponsInRightHandSlots[_currentRightWeaponIndex], false);
            }
            else
            {
                _currentRightWeaponIndex = _currentRightWeaponIndex + 1;
            }

            if (_currentRightWeaponIndex > _weaponsInRightHandSlots.Length -1)
            {
                _currentRightWeaponIndex = -1;
                _rightWeapon = _unarmedWeapon;
                _weaponSlotManager.LoadWeaponOnSlot(_unarmedWeapon, false);
            }
        }
        
        public void ChangeInLeftHandWeapon()
        {
            _currentLeftWeaponIndex = _currentLeftWeaponIndex + 1;

            if (_currentLeftWeaponIndex == 0 && _weaponsInLeftHandSlots[0] != null)
            {
                _leftWeapon = _weaponsInLeftHandSlots[_currentLeftWeaponIndex];
                _weaponSlotManager.LoadWeaponOnSlot(_weaponsInLeftHandSlots[_currentLeftWeaponIndex], false);
            }
            else if(_currentLeftWeaponIndex == 0 && _weaponsInLeftHandSlots[0] == null)
            {
                _currentLeftWeaponIndex = _currentLeftWeaponIndex + 1;
            }

            else if (_currentLeftWeaponIndex == 1 && _weaponsInLeftHandSlots[1] != null)
            {
                _leftWeapon = _weaponsInLeftHandSlots[_currentLeftWeaponIndex];
                _weaponSlotManager.LoadWeaponOnSlot(_weaponsInLeftHandSlots[_currentLeftWeaponIndex], false);
            }
            else
            {
                _currentLeftWeaponIndex = _currentLeftWeaponIndex + 1;
            }

            if (_currentLeftWeaponIndex > _weaponsInLeftHandSlots.Length -1)
            {
                _currentLeftWeaponIndex = -1;
                _leftWeapon = _unarmedWeapon;
                _weaponSlotManager.LoadWeaponOnSlot(_unarmedWeapon, false);
            }
        }
    }
}
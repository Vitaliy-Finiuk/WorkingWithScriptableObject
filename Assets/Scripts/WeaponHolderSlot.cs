using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS5
{
    public class WeaponHolderSlot : MonoBehaviour
    {
        [SerializeField] private Transform _parentOverride;
        [SerializeField] private GameObject _currentWeaponModel;
        
        public bool IsLeftHandSlot;
        public bool IsRightHandSlot;

        
        public void UnloadWeapon()
        {
            if (_currentWeaponModel != null)
            {
                _currentWeaponModel.SetActive(false);
            }
        }

        public void UnloadWeaponAndDestroy()
        {
            if (_currentWeaponModel != null)
            {
                Destroy(_currentWeaponModel);
            }
        }

        public void LoadWeaponModel(WeaponItem weaponItem)
        {
            
            UnloadWeaponAndDestroy();
            
            if (weaponItem == null)
            {
                UnloadWeapon();
                
                return;
            }
            
            GameObject model = Instantiate(weaponItem.ModelPrefab) as GameObject;
            if (model != null)
            {
                if (_parentOverride != null)
                {
                    model.transform.parent = _parentOverride;
                }
                else
                {
                    model.transform.parent = transform;
                }
                
                model.transform.localPosition = Vector3.zero;
                model.transform.localRotation = Quaternion.identity;
                model.transform.localScale = Vector3.one;
            }

            _currentWeaponModel = model;
        }
    }
}

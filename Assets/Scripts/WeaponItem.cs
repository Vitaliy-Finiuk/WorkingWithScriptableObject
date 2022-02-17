using System.Collections;
using System.Collections.Generic;
using DS5;
using UnityEngine;

namespace DS5
{
    [CreateAssetMenu(menuName = "Items/Weapon Item")]
    public class WeaponItem : Item
    {
        public GameObject ModelPrefab;
        [SerializeField] private bool _isUnarmed;

        [Header("Idle Animations")] 
        public string Right_hand_idle;
        public string Left_hand_idle;
        
        
        [Header("One Handed Attack Animations")] [SerializeField]
        private string OH_Light_Attack;
        private string OH_Heavy_Attack;
    }
}

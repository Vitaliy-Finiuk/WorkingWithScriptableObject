using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS5
{
    public class Item : ScriptableObject
    {
        [Header("Item Information")]
        [SerializeField] protected Sprite ItemIcon;
        [SerializeField] protected string ItemName;
    }
}
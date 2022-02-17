using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DS5
{
    public class InputHandler : MonoBehaviour
    {
        
        [HideInInspector] public float MoveAmount;
        [HideInInspector] public float Vertical;
        [HideInInspector] public float Horizontal;

        public bool d_Pad_Up;
        public bool d_Pad_Down;
        public bool d_Pad_Left;
        public bool d_Pad_Right;

        private PlayerInput _inputActions;
        private PlayerInventory _playerInventory;

        private Vector2 _movementInput;


        private void Start()
        {
            _playerInventory = GetComponent<PlayerInventory>();
        }
        

        public void OnEnable()
        {
            if (_inputActions == null)
            {
                _inputActions = new PlayerInput();
                _inputActions.PlayerMovement.Movement.performed +=
                    _inputActions => _movementInput = _inputActions.ReadValue<Vector2>();
            }
            
            _inputActions.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Disable(); 
        }

        public void TickInput(float delta)
        {
            MovementInput(delta);
            HandleQuickSlotsInput();
        }

        private void MovementInput(float delta)
        {
            Horizontal = _movementInput.x;
            Vertical = _movementInput.y;

            MoveAmount = Mathf.Clamp01(Mathf.Abs(Horizontal) + Mathf.Abs(Vertical));

        }

        private void HandleQuickSlotsInput()
        {
            _inputActions.PlayerQuickSlots.DPadRight.performed += i => d_Pad_Right = true;
            _inputActions.PlayerQuickSlots.DPadleft.performed += i => d_Pad_Left = true;
            
            if (d_Pad_Right)
            {
                _playerInventory.ChangeInRightHandWeapon();
            }
            else if (d_Pad_Left)
            {
                _playerInventory.ChangeInLeftHandWeapon();
            }
        }
    }
}

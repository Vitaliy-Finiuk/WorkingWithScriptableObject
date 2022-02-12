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

        [SerializeField] private float _mouseX;
        [SerializeField] private float _mouseY;

        private PlayerInput _inputActions;

        private Vector2 _movementInput;
        private Vector2 _cameraInput;


        public void OnEnable()
        {
            if (_inputActions == null)
            {
                _inputActions = new PlayerInput();
                _inputActions.PlayerMovement.Movement.performed +=
                    _inputActions => _movementInput = _inputActions.ReadValue<Vector2>();

                _inputActions.PlayerMovement.Camera.performed += i => _cameraInput = i.ReadValue<Vector2>();
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
        }

        private void MovementInput(float delta)
        {
            Horizontal = _movementInput.x;
            Vertical = _movementInput.y;

            MoveAmount = Mathf.Clamp01(Mathf.Abs(Horizontal) + Mathf.Abs(Vertical));
            _mouseX = _cameraInput.x;
            _mouseY = _cameraInput.y;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS5
{
    
    [RequireComponent(typeof(InputHandler), typeof(PlayerLocomotion))]
    public class PlayerManager : MonoBehaviour
    {

        private InputHandler _inputHandler;
        private PlayerLocomotion _playerLocomotion;

        private void Start()
        {
            _inputHandler = GetComponent<InputHandler>();
            _playerLocomotion = GetComponent<PlayerLocomotion>();
        }

        private void Update()
        {
            float delta = Time.deltaTime;

            _inputHandler.TickInput(delta);
            _playerLocomotion.HandleMovement(delta);
        }

        private void LateUpdate()
        {
            _inputHandler.d_Pad_Up = false;
            _inputHandler.d_Pad_Down = false;
            _inputHandler.d_Pad_Left = false;
            _inputHandler.d_Pad_Right = false;
        }
    }
}

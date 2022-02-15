using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS5
{
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
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DS5;

namespace DS5
{
    public class PlayerLocomotion : MonoBehaviour
    {
        private InputHandler _inputHandler;

        private Transform _cameraObject;
        private Transform _myTransform;
        private Vector3 _moveDirection;



        private Rigidbody _rigidbody;
        private GameObject _normalCamera;
        
        [Header("Stats")] 
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _inputHandler = GetComponent<InputHandler>();

            _cameraObject = Camera.main.transform;
            _myTransform = transform;
        }

        private void Update()
        {
            var delta = Time.deltaTime;
                     
                     _inputHandler.TickInput(delta);
         
                     _moveDirection = _cameraObject.forward * _inputHandler.Vertical;
                     _moveDirection += _cameraObject.right * _inputHandler.Horizontal;
                     _moveDirection.Normalize();
                     
            var speed = _movementSpeed;
             _moveDirection *= speed;
                                      
             Vector3 projectedVelocity = Vector3.ProjectOnPlane(_moveDirection, _normalVector);
             _rigidbody.velocity = projectedVelocity;
             
             HandleRotation(delta);
        }

        private void PlayerMover()
        {
            
        
            
        }

        #region Movement

        private Vector3 _normalVector;
        private Vector3 _targetPosition;

        private void HandleRotation(float delta)
        {
            var targetDirection = Vector3.zero;
            float moveOverride = _inputHandler.MoveAmount;

            targetDirection = _cameraObject.forward * _inputHandler.Vertical;
            targetDirection += _cameraObject.right * _inputHandler.Horizontal;

            targetDirection.Normalize();
            targetDirection.z = 0;

            if (targetDirection == Vector3.zero)
            {
                targetDirection = _myTransform.forward;
            }

            float rs= _rotationSpeed;
                
                var tr = Quaternion.LookRotation(targetDirection);
                var targetRotation = Quaternion.Slerp(_myTransform.rotation, tr, rs * delta);

                _myTransform.rotation = targetRotation;
            
        }

        #endregion
    }
}

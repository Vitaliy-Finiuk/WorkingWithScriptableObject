using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DS5
{
    
    [RequireComponent(typeof(Rigidbody), typeof(InputHandler), typeof(AnimationHandler))]
    public class PlayerLocomotion : MonoBehaviour
    {
        private InputHandler _inputHandler;
        private AnimationHandler _animationHandler;

        [SerializeField] private Transform _cameraObject;
        private Transform _myTransform;
        private Vector3 _moveDirection;



        private new Rigidbody _rigidbody;
        private GameObject _normalCamera;
        
        [Header("Movement Stats")] 
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _inputHandler = GetComponent<InputHandler>();
            _animationHandler = GetComponentInChildren<AnimationHandler>();
            

            _myTransform = transform;
            
            _animationHandler.Initialize();
        }
        
        #region Movement

        private Vector3 _normalVector;
        private Vector3 _targetPosition;

        public void HandleMovement(float delta)
        {
            _moveDirection = _cameraObject.forward * _inputHandler.Vertical;
            _moveDirection += _cameraObject.right * _inputHandler.Horizontal;
            _moveDirection.Normalize();
                     
            var speed = _movementSpeed;
            _moveDirection *= speed;
                                      
            var projectedVelocity = Vector3.ProjectOnPlane(_moveDirection, _normalVector);
            _rigidbody.velocity = projectedVelocity;
             

            _animationHandler.UpdateAnimatorValues(_inputHandler.MoveAmount, 0);
             
            if (_animationHandler.CanRotateMovement)
            {
                HandleRotation(delta);
            }
        }
        private void HandleRotation(float delta)
        {
            var targetDirection = Vector3.zero;
            float moveOverride = _inputHandler.MoveAmount;

            targetDirection = _cameraObject.forward * _inputHandler.Vertical;
            targetDirection += _cameraObject.right * _inputHandler.Horizontal;

            targetDirection.Normalize();
            targetDirection.y = 0;

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

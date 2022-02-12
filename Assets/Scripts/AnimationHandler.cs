using UnityEngine;

namespace DS5
{
    public class AnimationHandler: MonoBehaviour
    {
        [HideInInspector] public Animator Animator;
        
        [HideInInspector] public bool CanRotateMovement;

        private int _vertical;
        private int _horizontal;
        
        
        
        public void Initialize()
        {
            Animator = GetComponent<Animator>();
            _vertical = Animator.StringToHash("Vertical");
            _horizontal = Animator.StringToHash("Horizontal");
        }

        public void UpdateAnimatorValues(float verticalMovement, float horizontalMovement)
        {
            #region Vertical

            float v = 0;

            if (verticalMovement is > 0 and < 0.55f)
            {
                v = 0.5f;
            } else if (verticalMovement > 0.55f)
            {
                v = 1;
            }else if (verticalMovement is < 0 and > -0.55f)
            {
                v = -0.5f;
            }else if (verticalMovement < -0.55f)
            {
                v = -1f;
            }
            else
            {
                v = 0;
            }

            #endregion
            
            #region Horizontal

            float h = 0;

            if (verticalMovement is > 0 and < 0.55f)
            {
                h = 0.5f;
            } else if (verticalMovement > 0.55f)
            {
                h = 1;
            }else if (verticalMovement is < 0 and > -0.55f)
            {
                h = -0.5f;
            }else if (verticalMovement < -0.55f)
            {
                h = -1f;
            }
            else
            {
                h = 0;
            }

            #endregion
            
            Animator.SetFloat(_vertical, v, 0.1f, Time.deltaTime);
            Animator.SetFloat(_horizontal, h, 0.1f, Time.deltaTime);
        }

        public void CanRotate()
        {
            CanRotateMovement = true;
        }

        public void StopRotation()
        {
            CanRotateMovement = false;
        }
    }
}
using Simulator.Interfaces;
using UnityEngine;

namespace Simulator.Player
{
    public class PlayerManager : MonoBehaviour
    {
        internal Vector2 horizontalInput;
        internal Vector3 verticalVelocity;
        internal bool isJump;
        internal bool isGrounded;
        
        public CharacterController characterController;
        public float movementSpeed;
        public float jumpHeight;
        public float gravity = -30f;
        public LayerMask groundMask;

        private void Update()
        {
            // _isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);
            // if (_isGrounded) _verticalVelocity.y = 0;
            //
            // Vector3 horizontalVelocity =
            //     (transform.right * _horizontalInput.x + transform.forward * _horizontalInput.y) * movementSpeed;
            //
            // characterController.Move(horizontalVelocity * Time.deltaTime);
            //
            // if (_isJump)
            // {
            //     if (_isGrounded)
            //     {
            //         _verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            //     }
            //
            //     _isJump = false;
            // }
            //
            // _verticalVelocity.y += gravity * Time.deltaTime;
            // characterController.Move(_verticalVelocity * Time.deltaTime);
        }

        internal void OnInteractionPressed()
        {
            Vector3 screenCenter = new Vector3(0.5f, 0.5f, 0f);
            Ray ray = Camera.main!.ViewportPointToRay(screenCenter);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Interactable hitInteractable = hit.collider.GetComponent<Interactable>();
                
                if(hitInteractable == null) return;
                hitInteractable.OnClickEvent();
            }
        }
        
        internal void OnJumpPressed()
        {
            isJump = true;
        }

        internal void ReceiveInput(Vector2 horizontalInput)
        {
            this.horizontalInput = horizontalInput;
        }
    }
}

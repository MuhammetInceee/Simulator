using Simulator.Interfaces;
using UnityEngine;

namespace Simulator.Player
{
    public class PlayerManager : MonoBehaviour
    {
        private Vector2 _horizontalInput;
        private Vector3 _verticalVelocity;
        private bool _isJump;
        private bool _isGrounded;
        
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float jumpHeight;
        [SerializeField] private float gravity = -30f;
        [SerializeField] private LayerMask groundMask;

        private void Update()
        {
            _isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);
            if (_isGrounded) _verticalVelocity.y = 0;

            Vector3 horizontalVelocity =
                (transform.right * _horizontalInput.x + transform.forward * _horizontalInput.y) * movementSpeed;

            characterController.Move(horizontalVelocity * Time.deltaTime);

            if (_isJump)
            {
                if (_isGrounded)
                {
                    _verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
                }

                _isJump = false;
            }

            _verticalVelocity.y += gravity * Time.deltaTime;
            characterController.Move(_verticalVelocity * Time.deltaTime);
        }

        internal void OnInteractionPressed()
        {
            Vector3 screenCenter = new Vector3(0.5f, 0.5f, 0f);
            Ray ray = Camera.main!.ViewportPointToRay(screenCenter);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                IInteractable hitInteractable = hit.collider.GetComponent<IInteractable>();
                
                if(hitInteractable == null) return;
                hitInteractable.OnClickEvent();
            }
        }
        
        internal void OnJumpPressed()
        {
            _isJump = true;
        }

        internal void ReceiveInput(Vector2 horizontalInput)
        {
            _horizontalInput = horizontalInput;
        }
    }
}

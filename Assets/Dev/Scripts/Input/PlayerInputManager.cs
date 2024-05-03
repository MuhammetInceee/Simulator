using UnityEngine;

namespace Simulator.Player
{
    public class PlayerInputManager : MonoBehaviour
    {
        private PlayerInputs _playerControlIS;
        private PlayerInputs.MovementActions _groundMovement;
        private PlayerInputs.InteractionActions _interaction;
        
        private Vector2 _horizontalInput;
        private Vector2 _mouseInput;
        
        [SerializeField] private PlayerManager playerManager;
        [SerializeField] private MouseController mouseController;

        private void Awake()
        {
            SetReferences();
            _groundMovement = _playerControlIS.Movement;
            _interaction = _playerControlIS.Interaction;

            _groundMovement.HorizontalMovement.performed += ctx => _horizontalInput = ctx.ReadValue<Vector2>();
            
            _groundMovement.Jump.performed += _ => playerManager.OnJumpPressed();
            _interaction.InteractionKey.performed += _ => playerManager.OnInteractionPressed();

            _groundMovement.MouseX.performed += ctx => _mouseInput.x = ctx.ReadValue<float>();
            _groundMovement.MouseY.performed += ctx => _mouseInput.y = ctx.ReadValue<float>();
        }

        private void SetReferences()
        {
            _playerControlIS = new PlayerInputs();
            if (!playerManager) playerManager = GetComponent<PlayerManager>();
            if (!mouseController) mouseController = GetComponent<MouseController>();
        }

        private void Update()
        {
            playerManager.ReceiveInput(_horizontalInput);
            mouseController.ReceiveInput(_mouseInput);
        }

        private void OnEnable()
        {
            _playerControlIS.Enable();
        }

        private void OnDisable()
        {
            _playerControlIS.Disable();
        }
    }
}

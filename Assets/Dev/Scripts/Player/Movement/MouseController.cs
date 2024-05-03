using UnityEngine;

namespace Simulator.Player
{
    public class MouseController : MonoBehaviour
    {
        private float _mouseX;
        private float _mouseY;
        private float _xRotation;
        
        [SerializeField] private float sensitivityX = 8f;
        [SerializeField] private float sensitivityY = 0.5f;

        [SerializeField] private Transform playerCamera;
        [SerializeField] private float xClamp = 85f;

        private void Awake()
        {
            SetReferences();
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void SetReferences()
        {
            if (!playerCamera) playerCamera = Camera.main!.transform;
        }

        private void Update()
        {
            transform.Rotate(Vector3.up, _mouseX * Time.deltaTime);

            _xRotation -= _mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -xClamp, xClamp);

            Vector3 targetRotation = transform.eulerAngles;
            targetRotation.x = _xRotation;
            playerCamera.eulerAngles = targetRotation;
        }

        public void ReceiveInput(Vector2 mouseInput)
        {
            _mouseX = mouseInput.x * sensitivityX;
            _mouseY = mouseInput.y * sensitivityY;
        }
    }
}

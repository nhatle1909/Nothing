using Cinemachine;
using UnityEngine;
namespace Assets.Script
{
    public class PlayerMovement : MonoBehaviour
    {
        // This script will be refactor soon
        public CinemachineVirtualCamera VirtualCamera;
        public Rigidbody rb;

        [SerializeField] private float speedMultiplier = 0.9f;
        [SerializeField] private float mouseSensitivity = 20f;
        private float _xRotation;
        private Vector3 moveDirection;
        void Start()
        {


            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Player_Move();

        }
        private void LateUpdate()
        {
            CameraMove();
        }
        public void Player_Move()
        {

            speedMultiplier = InputManager.instance.Running ? 2f : 1f;

            float xAxis = InputManager.instance.Move.x * speedMultiplier;
            float yAxis = InputManager.instance.Move.y * speedMultiplier;

            moveDirection = new Vector3(xAxis, 0f, yAxis);

            rb.velocity = transform.TransformVector(moveDirection);
        }

        public void CameraMove()
        {
            //Get Input from mouse movement, not use InputAction ( Calculate is too tiring ) 
            var Mouse_X = Input.GetAxis("Mouse X");
            //Rotate body following X Axis
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0, Mouse_X * mouseSensitivity * Time.smoothDeltaTime, 0));
        }

    }
}

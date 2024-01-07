using Cinemachine;
using UnityEngine;
namespace Assets.Script
{
    public class PlayerMovement : MonoBehaviour
    {
        // This script will be refactor soon
        public CinemachineVirtualCamera VirtualCamera;
        public Rigidbody rb;
        public Animator animator;

        [SerializeField] private float speedMultiplier = 0.9f;
        [SerializeField] private float mouseSensitivity = 20f;
        public float xAxis,yAxis;
        private Vector3 moveDirection;
        void Start()
        {
            animator = GetComponent<Animator>();

            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {

       
            Player_Move();
            Player_Animate();

        }
        private void LateUpdate()
        {
            CameraMove();
        }
        public void Player_Move()
        {

            speedMultiplier = InputManager.instance.Running ? 3f : 1.5f;

            xAxis = InputManager.instance.Move.x * speedMultiplier;
            yAxis = InputManager.instance.Move.y * speedMultiplier;
            moveDirection = new Vector3(xAxis, 0f, yAxis);

            rb.velocity = transform.TransformVector(moveDirection);
            rb.AddForce(Vector3.down * 10f, ForceMode.Acceleration); // Gravity
        }

        public void CameraMove()
        {
            //Get Input from mouse movement, not use InputAction ( Calculate is too tiring ) 
            var Mouse_X = Input.GetAxis("Mouse X");
            //Rotate body following X Axis
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0, Mouse_X * mouseSensitivity * Time.smoothDeltaTime, 0));
        }
        public void Player_Animate() 
        {
            animator.SetBool(AnimationParameterManager.Running, moveDirection != Vector3.zero);
            animator.SetFloat(AnimationParameterManager.HorizonAxis,xAxis);
            animator.SetFloat(AnimationParameterManager.VerticalAxis,yAxis);
        }
    
    }
}

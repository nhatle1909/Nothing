
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
namespace Assets.Script
{
    public class InputManager : MonoBehaviour
    {

        // Use this for initialization
        [SerializeField] private PlayerInput inputManager;
        public Vector3 Move { get; private set; }
        public Vector3 Look { get; private set; }
        public bool Interact { get; private set; }
        public bool Running { get; private set; }

        private InputActionMap _currentMap;
        private InputAction _moveAction;
        private InputAction _lookAction;
        private InputAction _interactAction;
        private InputAction _runningAction;
        private void Awake()
        {
            _currentMap = inputManager.currentActionMap;
            _moveAction = _currentMap.FindAction("Move");
            _lookAction = _currentMap.FindAction("Look");
            _interactAction = _currentMap.FindAction("Interact");
            _runningAction = _currentMap.FindAction("Running");

            _moveAction.performed += onMove;
            _runningAction.performed += onRunning;
            _lookAction.performed += onLook;
            _interactAction.performed += onInteract;
            

            _moveAction.canceled += onMove;
            _runningAction.canceled += onRunning;
            _lookAction.canceled += onLook;
            _interactAction.canceled += onInteract;
            
        }
        public void onMove(InputAction.CallbackContext context)
        {
           Move = context.ReadValue<Vector3>();
        }
        public void onRunning(InputAction.CallbackContext context)
        {
            Running = context.ReadValue<bool>();
            
        }
        public void onLook(InputAction.CallbackContext context) 
        {
            Look = context.ReadValue<Vector2>();
        }
        public void onInteract(InputAction.CallbackContext context) 
        {
            Interact = context.ReadValue<bool>();
        }
        
    }
}
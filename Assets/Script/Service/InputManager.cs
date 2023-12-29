
using UnityEngine;
using UnityEngine.InputSystem;
namespace Assets.Script
{
    public class InputManager : MonoBehaviour
    {
        // Remove uncessary subscriber
        [SerializeField] private PlayerInput inputManager;

        public static InputManager instance;
        public Vector3 Move { get; private set; }
        public Vector3 Look { get; private set; }
        public bool Interact { get; private set; }
        public bool Running { get; private set; }

        private InputActionMap _currentMap;
        private InputAction _moveAction;
        private InputAction _lookAction;
        private InputAction _runningAction;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            _currentMap = inputManager.currentActionMap;

            _moveAction = _currentMap.FindAction("Move");
            _lookAction = _currentMap.FindAction("Look");
            _runningAction = _currentMap.FindAction("Running");

            _moveAction.performed += onMove;
            _lookAction.performed += onLook;

            
            _runningAction.canceled += onRunning;
            _lookAction.canceled += onLook;

        }
        public void onMove(InputAction.CallbackContext context)
        {
            Move = context.ReadValue<Vector3>();
            Debug.Log("Moving");
        }
        public void onRunning(InputAction.CallbackContext context)
        {
            Running = context.ReadValue<bool>();

        }
        public void onLook(InputAction.CallbackContext context)
        {
            Look = context.ReadValue<Vector2>();
            
        }

        // Bug at subscribe event Interact
        // Use binding manually because can not subscribe event ( do not know why the script does not run the line subscribe event ) 
        public void onInteract(InputAction.CallbackContext context)
        {
           if ( context.performed) Interact = true;
           if ( context.canceled) Interact = false;
        }

    }
}
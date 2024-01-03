
using UnityEngine;
using UnityEngine.InputSystem;
namespace Assets.Script
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private PlayerInput inputManager;

        public static InputManager instance;
        public Vector3 Move { get; private set; }
        public Vector3 Look { get; private set; }
        public bool Interact { get; private set; }
        public bool Running { get; private set; }
        public bool EscSetting { get; private set; }
        public bool Inventory { get; private set; }

        private InputActionMap _currentMap;
        private InputAction _moveAction;
        private InputAction _lookAction;
        private InputAction _runningAction;
        private InputAction _interactAction;
        private InputAction _escAction;
        private InputAction _inventoryAction;
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
            _interactAction = _currentMap.FindAction("Interact");
            _escAction = _currentMap.FindAction("System");
            _inventoryAction = _currentMap.FindAction("Inventory");

            _moveAction.performed += onMove;
            _lookAction.performed += onLook;
            _runningAction.performed += onRunning;
            _interactAction.performed += onInteract;
            _escAction.performed += onSystemSetting;
            _inventoryAction.performed += onInventory;

            _runningAction.canceled += outRunning;
            _interactAction.canceled += outRunning;




        }
        public void onMove(InputAction.CallbackContext context)
        {
            Move = context.ReadValue<Vector3>();

        }
        public void onRunning(InputAction.CallbackContext context)
        {
            Running = true;

        }

        public void onLook(InputAction.CallbackContext context)
        {
            Look = context.ReadValue<Vector2>();

        }
        public void onSystemSetting(InputAction.CallbackContext context)
        {
            if (EscSetting == true) EscSetting = false;
            else EscSetting = true;

        }
        public void onInventory(InputAction.CallbackContext context)
        {
            if (Inventory == true) Inventory = false;
            else Inventory = true;
        }
        public void onInteract(InputAction.CallbackContext context)
        {
            Interact = true;
        }

        // ---------------------------------------- //

        public void outRunning(InputAction.CallbackContext context)
        {
            Running = false;
        }
        public void outInteract(InputAction.CallbackContext context)
        {
            Interact = false;
        }

    }
}
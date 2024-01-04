using UnityEngine;

namespace Assets.Script.EventSystem
{
    public class DoorEvent : MonoBehaviour
    {
        public int doorID;
        public int triggerID;
        public bool isOpenDoor;
        // Use this for initialization
        void Start()
        {
            EventManager.instance.OpenDoor += OpenDoorEvent;
        }

        private void Update()
        {
            if (doorID == 1)
            {
                Debug.Log(transform.localEulerAngles);
            }

        }
        // Update is called once per frame
        void OpenDoorEvent(int triggerID)
        {
            if (triggerID == doorID)
            {
                transform.localEulerAngles = new Vector3(0f, 65f, 0f);
                EventManager.instance.OpenDoor -= OpenDoorEvent;
                EventManager.instance.CloseDoor += CloseDoorEvent;
            }
        }
        void CloseDoorEvent(int triggerID)
        {
            if (triggerID == doorID)
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
                EventManager.instance.OpenDoor += OpenDoorEvent;
                EventManager.instance.CloseDoor -= CloseDoorEvent;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player" && InputManager.instance.Interact == true)
            {
                if (isOpenDoor == false)
                {

                    EventManager.instance.OpenDoorTrigger(triggerID);
                    isOpenDoor = true;
                }
                else
                {
                    EventManager.instance.CloseDoorTrigger(triggerID);
                    isOpenDoor = false;
                }
            }
        }

    }
}
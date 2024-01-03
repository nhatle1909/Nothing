using UnityEngine;

namespace Assets.Script.EventSystem
{
    public class OpenDoor : MonoBehaviour
    {
        public int doorID;
        public int triggerID;
        // Use this for initialization
        void Start()
        {
            EventManager.instance.OpenDoor += OpenDoorEvent;
        }

        // Update is called once per frame
        void OpenDoorEvent(int triggerID)
        {
            if (triggerID == doorID)
            {
                transform.eulerAngles = new Vector3(0, 45f, 0);
                EventManager.instance.OpenDoor -= OpenDoorEvent;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player" && InputManager.instance.Interact == true)
            {
                EventManager.instance.OpenDoorTrigger(triggerID);
            }
        }
    }
}
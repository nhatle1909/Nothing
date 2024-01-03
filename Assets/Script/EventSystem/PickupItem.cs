using UnityEngine;

namespace Assets.Script.EventSystem
{
    public class PickupItem : MonoBehaviour
    {
        public int itemID;
        public int triggerID;
        // Use this for initialization
        void Start()
        {
            EventManager.instance.PickupItem += PickupItemEvent;
        }

        // Update is called once per frame
        void PickupItemEvent(int triggerID)
        {
            if (triggerID == itemID)
            {
                transform.eulerAngles = new Vector3(0, 45f, 0);
                EventManager.instance.OpenDoor -= PickupItemEvent;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player" && InputManager.instance.Interact == true)
            {
                EventManager.instance.PickupItemTrigger(triggerID);
            }
        }
    }
}
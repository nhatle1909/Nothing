using UnityEngine;

namespace Assets.Script.EventSystem
{
    public class OpenDoor : MonoBehaviour
    {
        public int doorID;
        // Use this for initialization
        void Start()
        {
            EventManager.instance.OpenDoor += OpenDoorEvent;
        }

        // Update is called once per frame
        void OpenDoorEvent()
        {
            transform.eulerAngles = new Vector3(0, 90f, 0); 
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player" && InputManager.instance.Interact == true)
            {
                EventManager.instance.OpenDoorTrigger();
            }
        }
        

    }
}
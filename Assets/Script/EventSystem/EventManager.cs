using System;
using UnityEngine;

namespace Assets.Script
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager instance;

        public event Action<int> OpenDoor;
        public event Action<int> CloseDoor;
        public event Action<int> PickupItem;

        private void Awake()
        {
            instance = this;
        }
        public void OpenDoorTrigger(int triggerId)
        {
            OpenDoor?.Invoke(triggerId);
        }
        public void PickupItemTrigger(int triggerId)
        {
            PickupItem?.Invoke(triggerId);
        }
        public void CloseDoorTrigger(int triggerId)
        {
            CloseDoor?.Invoke(triggerId);
        }


    }
}
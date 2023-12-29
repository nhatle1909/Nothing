using System;
using UnityEngine;

namespace Assets.Script
{
    public class EventManager : MonoBehaviour
    {
        public event Action OpenDoor;
        public static EventManager instance;
        private void Awake()
        {
            instance = this;
        }
        public void OpenDoorTrigger()
        {
            OpenDoor?.Invoke();
        }
        // Use this for initialization



    }
}
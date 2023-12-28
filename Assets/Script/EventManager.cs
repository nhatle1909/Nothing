using System;
using System.Collections;
using UnityEngine;

namespace Assets.Script
{
    public class EventManager : MonoBehaviour
    {
        public event Action OpenDoor;
        public void DoThing()
        {
            OpenDoor?.Invoke();
        }
        // Use this for initialization
        void Start()
        {

        }

       
    }
}
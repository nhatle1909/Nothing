using System.Collections;
using UnityEngine;

namespace Assets.Script.CanvasScript
{
    public class SettingsScript : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (InputManager.instance.EscSetting == true) 
            {
                gameObject.SetActive(true);
            }
            else 
            {
                gameObject.SetActive(false);
            }
        }
        
    }
}
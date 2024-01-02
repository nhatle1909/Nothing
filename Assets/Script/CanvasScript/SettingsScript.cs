using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.CanvasScript
{
    public class SettingsScript : MonoBehaviour
    {
        public Canvas canvas;
        public AudioSource audioSource;
        public Slider musicBar;
        // Use this for initialization
        void Start()
        {
          canvas = GetComponent<Canvas>();
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(InputManager.instance.EscSetting);
            if (InputManager.instance.EscSetting == true) 
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                canvas.enabled = true;
            }
            else 
            {
                Cursor.lockState = CursorLockMode.Locked;
                canvas.enabled = false;
            }
        }
        public void onMusicVolumeChanged() 
        {
            audioSource.volume = musicBar.value;
        }
    }
}
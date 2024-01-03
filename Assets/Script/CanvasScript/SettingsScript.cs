using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.CanvasScript
{
    public class SettingsScript : MonoBehaviour
    {
        public GameObject canvasSettings, canvasInventory;
        public AudioSource audioSource;
        public Slider musicBar;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (InputManager.instance.EscSetting == true)
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                canvasSettings.SetActive(true);
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                canvasSettings.SetActive(false);
            }

            if (InputManager.instance.Inventory == true)
            {
                canvasInventory.SetActive(true);
            }
            else { canvasInventory.SetActive(false); }
        }

        public void onMusicVolumeChanged()
        {
            audioSource.volume = musicBar.value;
        }
    }
}
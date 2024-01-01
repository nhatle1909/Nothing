using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    // Start is called before the first frame update
    internal readonly string MainGame = "MainGame";

    public void StartGame() 
    {
        SceneManager.LoadSceneAsync(MainGame);
    }
    public void Exit() 
    {
        Application.Quit();
    }
}

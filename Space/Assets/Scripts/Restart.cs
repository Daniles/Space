using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart {
    
    public void RestartClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}

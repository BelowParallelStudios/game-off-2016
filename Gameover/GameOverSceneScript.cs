using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverSceneScript : MonoBehaviour {

    private bool retryBtn;
    private int currentLevel;
    
    void Start()
    {
        currentLevel = GameManager.instance.LevelInt; 
    }
    
    void OnGUI()
    {
        GameOverLabel();
        RetryButton();
    }
    
    private void GameOverLabel()
    {
        GUIStyle labelText = new GUIStyle(GUI.skin.label);
        labelText.fontSize = 72;
        GUI.Label(new Rect(Screen.width * 0.2f, Screen.height * 0.2f, Screen.width * 0.75f, Screen.height * 0.3f), "Game Over", labelText);
    }
    
    private void RetryButton()
    {
        retryBtn = GUI.Button(new Rect(Screen.width * 0.35f, Screen.height * 0.55f, Screen.width * 0.3f, Screen.height * 0.1f), "Retry");
        if (retryBtn)
        {
            SceneManager.LoadScene(currentLevel); 
        }
    }
}

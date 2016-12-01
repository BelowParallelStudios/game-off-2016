using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour {

    private bool startBtn;
    public Texture2D myGuiTexture;
    
    void OnGUI()
    {
        StartButton();   
    }
    
    private void StartButton()
    {
        GUIStyle buttonStyle = new GUIStyle (GUI.skin.button);
        buttonStyle.fontSize = Screen.width/28;
        buttonStyle.normal.textColor = Color.green;
        buttonStyle.normal.background = myGuiTexture;
        
        startBtn = GUI.Button(new Rect(Screen.width * 0.7f, Screen.height * 0.75f, Screen.width * 0.25f, Screen.height * 0.15f), "Start Game", buttonStyle);
        if (startBtn)
        {
            //load scene that explains narrative
            SceneManager.LoadScene(2);
        }
    }
    
}

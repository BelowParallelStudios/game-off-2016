using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    
    public static GameManager instance = null;

    public bool mineDetected;
    public bool neverDone;
    public bool showGameOver;
    public bool showVictory;
    private bool retryBtn;
    public bool showInstructions;
    private bool nextBtn1;
    private bool closeBtn;
    
    //MODS
    public bool haveMoneySensor;
    public bool haveInfraredScanner;
    public bool haveMoneySensorEquip;
    public bool haveInfraredScannerEquip;
    
    
    public string mineSensorString;
    public string moneySensorString;
    public string infraredScannerString;
    public string narrativeString1;
    public string narrativeString2;
    public string narrativeString3;
    public string victoryLabelString;
    
    private string sceneName;
    
    public int proxN;
    public int proxS;
    public int proxE;
    public int proxW;  
    
    public int moneyProxN;
    public int moneyProxS;
    public int moneyProxE;
    public int moneyProxW; 
    
    private int narrativeCounter;
    
    //INFRARED
    public string lastMove;
    
    public Texture mineTexture;
    public Texture moneyTexture;
    public Texture2D myGuiTexture;
    public Texture2D myGuiTextureBorderless;
    
    
	[SerializeField]
	private int money;
	public int Money { 
		get {
			return money;
		}
		set {
			money = value;
		}
	}
    
    private int mineSensor;
    public int MineSensor { 
        get {
            return mineSensor;
        }
        set {
            mineSensor = value;
        }
    }
    
    private int moneySensor;
    public int MoneySensor { 
        get {
            return moneySensor;
        }
        set {
            moneySensor = value;
        }
    }
    
    private int levelInt;
    public int LevelInt { 
        get {
            return levelInt;
        }
        set {
            levelInt = value;
        }
    }
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }
    
    void Start()
    {
        levelInt = 2;
        neverDone = true;
        proxE = 0;
        proxN = 0;
        proxS = 0;
        proxW = 0;
        
        lastMove = "up";   
        
        showInstructions = true;
        narrativeCounter = 1;
    }

    void Update()
    {       
        
       mineSensor = proxN + proxE + proxS + proxW;   
       mineSensorString = "" + mineSensor; 
        
        MoneySensorMethod();
        
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }
    
    //GUI STUFF
    void OnGUI()
    {      
        if (sceneName != "PostLvlScene")
        {
            MineSensorBox();
            
            if (haveMoneySensorEquip == true)
            {
                MoneySensorBox();
            }
            
            if (haveInfraredScannerEquip == true)
            {
                InfraredBox(); 
            }
        }
        
        if (showInstructions == true)
        {
            InstructionsBox();
            
            if (narrativeCounter == 1)
            {
                NarrativeLabel1();
                InstructionsNextButton();
            }
            else if (narrativeCounter == 2)
            {
                NarrativeLabel2();
                InstructionsNextButton();
            }
            else if (narrativeCounter == 3)
            {
                NarrativeLabel3();
                InstructionsCloseButton();
            }
            
        }
        
        if (showGameOver == true)
        {
            GameOverBox();
            RetryButton();
        }
        
        if (showVictory == true)
        {
            VictoryBox();
            VictoryLabel();
        }
       
    } 
    
    void InstructionsBox()
    {     
        Time.timeScale = 0;
        GUIStyle instructionsBox = new GUIStyle(GUI.skin.box);
        
        instructionsBox.fontSize = Screen.width/20;
        instructionsBox.normal.background = myGuiTexture;
   
        GUI.Box(new Rect(Screen.width * 0.25f, Screen.height * 0.2f, Screen.width * 0.5f, Screen.height * 0.62f), "Instructions", instructionsBox);
    }
    
    void NarrativeLabel1()
    {
        narrativeString1 = "You have been tasked with infiltrating Klanton Tower in order " +
            "to retrieve key information to be used as evidence against Billary Klanton in her " +
            "upcoming trial for treason. There is a mainframe on each floor of Klanton Tower " +
            "that must be hacked.";        
        
        GUIStyle howToTextStyle = new GUIStyle (GUI.skin.label);
        howToTextStyle.fontSize = Screen.width/48;
        howToTextStyle.normal.textColor = Color.green;
        howToTextStyle.alignment = TextAnchor.UpperCenter;
        howToTextStyle.wordWrap = true;
        
        GUI.Label(new Rect(Screen.width * 0.3f , Screen.height * 0.3f, Screen.width * 0.4f, Screen.height * 0.45f), narrativeString1, howToTextStyle);       
    }
    
    void NarrativeLabel2()
    {
        narrativeString2 = "It is too dangerous for you, yourself, to physically go into the tower. " +
        "The tower is booby-trapped with explosives. Fortunately, we have a high tech recon " +
        "robot that can do the tough work for you. Meet SpyBot 5000!";     

        GUIStyle howToTextStyle = new GUIStyle (GUI.skin.label);
        howToTextStyle.fontSize = Screen.width/48;
        howToTextStyle.normal.textColor = Color.green;
        howToTextStyle.alignment = TextAnchor.UpperCenter;
        howToTextStyle.wordWrap = true;

        GUI.Label(new Rect(Screen.width * 0.3f , Screen.height * 0.3f, Screen.width * 0.4f, Screen.height * 0.45f), narrativeString2, howToTextStyle);       
    }
    
    void NarrativeLabel3()
    {
        narrativeString3 = "Use WASD to move SpyBot. The contents of any given tile are hidden " +
            "until SpyBot has physically occupied the tile. Fortunately, however, SpyBot is " +
            "equipped with a sensor that can detect nearby mines. " +
            "The sensor, in the top left corner of your screen, will display a number that is equal to the amount of mines occupying " +
            "the 4 tiles adjacent to SpyBot. Any money you happen to find in the tower can be" +
            " used to purchase MODS for SpyBot that will improve its sensing capabilities." +
            " You must navigate SpyBot to the tile containing the Mainframe in order to hack" +
            " it and move on to the next level.";     

        GUIStyle howToTextStyle = new GUIStyle (GUI.skin.label);
        howToTextStyle.fontSize = Screen.width/48;
        howToTextStyle.normal.textColor = Color.green;
        howToTextStyle.alignment = TextAnchor.UpperCenter;
        howToTextStyle.wordWrap = true;

        GUI.Label(new Rect(Screen.width * 0.3f , Screen.height * 0.3f, Screen.width * 0.43f, Screen.height * 0.45f), narrativeString3, howToTextStyle);       
    }
    
    void InstructionsNextButton()
    {
        GUIStyle buttonStyle = new GUIStyle (GUI.skin.button);
        buttonStyle.fontSize = Screen.width/28;
        buttonStyle.normal.textColor = Color.green;
        buttonStyle.normal.background = myGuiTexture;
        
        nextBtn1 = GUI.Button(new Rect(Screen.width * 0.62f, Screen.height * 0.72f, Screen.width * 0.12f, Screen.height * 0.08f), "Next", buttonStyle);
        if (nextBtn1)
        {
            narrativeCounter += 1; 
        }
    }
    
    void InstructionsCloseButton()
    {
        GUIStyle buttonStyle = new GUIStyle (GUI.skin.button);
        buttonStyle.fontSize = Screen.width/28;
        buttonStyle.normal.textColor = Color.green;
        buttonStyle.normal.background = myGuiTexture;

        closeBtn = GUI.Button(new Rect(Screen.width * 0.62f, Screen.height * 0.72f, Screen.width * 0.12f, Screen.height * 0.08f), "Close", buttonStyle);
        if (closeBtn)
        {
            narrativeCounter = 0; 
            showInstructions = false;
            Time.timeScale = 1;
        }
    }
    
    void GameOverBox()
    {
        GUIStyle gameOverBox = new GUIStyle(GUI.skin.box);
        gameOverBox.fontSize = Screen.width / 20;
        gameOverBox.normal.textColor = Color.green;
        gameOverBox.normal.background = myGuiTexture;
        
        GUI.Box(new Rect(Screen.width * 0.25f, Screen.height * 0.25f, Screen.width * 0.5f, Screen.height * 0.65f), "Game Over", gameOverBox);
    }
    
    private void RetryButton()
    {
        GUIStyle buttonStyle = new GUIStyle (GUI.skin.button);
        buttonStyle.fontSize = Screen.width/28;
        buttonStyle.normal.textColor = Color.green;
        buttonStyle.normal.background = myGuiTexture;
        
        retryBtn = GUI.Button(new Rect(Screen.width * 0.35f, Screen.height * 0.55f, Screen.width * 0.3f, Screen.height * 0.1f), "Retry", buttonStyle);
        if (retryBtn)
        {
            //Destroy(gameObject);
            Money = 0;
            proxE = 0;
            proxN = 0;
            proxS = 0;
            proxW = 0;
            lastMove = "up";
            Time.timeScale = 1;
            showGameOver = false;
            SceneManager.LoadScene(levelInt); 
            
        }
    }
    
    void VictoryBox()
    {
        GUIStyle victoryBoxStyle = new GUIStyle(GUI.skin.box);
        victoryBoxStyle.fontSize = Screen.width / 20;
        victoryBoxStyle.normal.textColor = Color.green;
        victoryBoxStyle.normal.background = myGuiTexture;
        
        GUI.Box(new Rect(Screen.width * 0.25f, Screen.height * 0.25f, Screen.width * 0.5f, Screen.height * 0.65f), "Congratulations!", victoryBoxStyle);
    }
    
    void VictoryLabel()
    {
        victoryLabelString = "You have collected enough evidence to put Klanton behind bars for a long time. Great work, patriot!";  

        GUIStyle victoryTextStyle = new GUIStyle (GUI.skin.label);
        victoryTextStyle.fontSize = Screen.width/36;
        victoryTextStyle.normal.textColor = Color.green;
        victoryTextStyle.alignment = TextAnchor.UpperCenter;
        victoryTextStyle.wordWrap = true;

        GUI.Label(new Rect(Screen.width * 0.3f , Screen.height * 0.35f, Screen.width * 0.43f, Screen.height * 0.45f), victoryLabelString, victoryTextStyle);       
    }
    
    private void MoneySensorMethod()
    {
        if (haveMoneySensorEquip == true)
        {
            moneySensor = moneyProxN + moneyProxE + moneyProxS + moneyProxW;   
            moneySensorString = "" + moneySensor; 
        }
    }
    
    public void MineSensorBox() 
    {
        GUIContent mineContent = new GUIContent(mineSensorString, mineTexture);
        GUIStyle myBoxStyle = new GUIStyle(GUI.skin.box);
        myBoxStyle.fontSize = 35;
        myBoxStyle.normal.background =  MakeTex(2, 2, new Color(0.3f, 0.3f, 0.6f, 1f));
        GUI.Box(new Rect(Screen.width * 0.02f , Screen.height * 0.02f, Screen.width * 0.2f, Screen.height * 0.1f), mineContent, myBoxStyle);       
    } 
          
    
    void MoneySensorBox() 
    {
        GUIContent moneyContent = new GUIContent(moneySensorString, moneyTexture);
        GUIStyle myBoxStyle = new GUIStyle(GUI.skin.box);
        myBoxStyle.fontSize = 35;
        myBoxStyle.normal.background =  MakeTex(2, 2, new Color(0.3f, 0.6f, 0.3f, 1f));
        GUI.Box(new Rect(Screen.width * 0.02f , Screen.height * .12f, Screen.width * 0.2f, Screen.height * 0.1f), moneyContent, myBoxStyle); 
    }
    
    void InfraredBox() 
    {
        GUIStyle myBoxStyle = new GUIStyle(GUI.skin.box);
        // GUIStyle howToTextStyle = new GUIStyle (GUI.skin.box);
        myBoxStyle.fontSize = 26;
        myBoxStyle.normal.background =  MakeTex(2, 2, new Color(0.6f, 0.3f, 0.3f, 1f));
        // howToTextStyle.fontSize = 13;
        // howToTextStyle.normal.background = MakeTex(2, 2, new Color(0.6f, 0.3f, 0.3f, 1f));
        //howToTextStyle.wordWrap = true;
        GUI.Box(new Rect(Screen.width * 0.02f , Screen.height * .12f, Screen.width * 0.2f, Screen.height * 0.1f), infraredScannerString, myBoxStyle);
        //GUI.Box(new Rect(Screen.width * 0.29f , Screen.height * 0.2f, Screen.width * 0.5f, Screen.height * 0.7f), howToPlayString, howToTextStyle);
    }
    
   // WHY NOT JUST MAKE THE GAMEMANAGER TOTALLY BLOATED?????
    
    private Texture2D MakeTex( int width, int height, Color col )
    {
        Color[] pix = new Color[width * height];
        for( int i = 0; i < pix.Length; ++i )
        {
            pix[ i ] = col;
        }
        Texture2D result = new Texture2D( width, height );
        result.SetPixels( pix );
        result.Apply();
        return result;
    }
}

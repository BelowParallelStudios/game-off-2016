using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PostLvlScript : MonoBehaviour {

    private bool buyOneBtn;
    private bool buyTwoBtn;
    private bool equipOneBtn;
    private bool equipTwoBtn;
    private bool nextLvlBtn;
    
    private string moneySensorString;
    private string infraredScannerString;
    private string whatIsEquipped;
    
    private int currentMoney;
    
    public Texture2D myGuiTexture;
    
    
    void Start()
    {
        moneySensorString = "The Money Sensor displays a number \n" +
            "corresponding to the amount of money \n " +
        "in adjacent tiles.";
        
        infraredScannerString = "The Infrared Scanner allows you \n" +
        "to see the contents of the tile \n" +
        "you are facing.";
        
        whatIsEquipped = "nothing";
    }
    
    void Update()
    {
        if (GameObject.Find("GameManager"))
            {
                currentMoney = GameManager.instance.Money;
            }
        
        EquipUpdateMethod();
    }
    
    void OnGUI()
    {
        ModShopBox();
        
        MoneySensorBox();
        BuyOneButton();
        EquipOneButton();
        
        InfraredScannerBox();
        BuyTwoButton();
        EquipTwoButton();
        
        EquippedLabel();
        
        CurrentMoneyLabel();
        
        NextLvlButton();
    }

    void ModShopBox()
    {
        GUIStyle modShopBoxStyle = new GUIStyle(GUI.skin.box);
        modShopBoxStyle.fontSize = Screen.width / 15;
        modShopBoxStyle.normal.background = myGuiTexture;
        GUI.Box(new Rect(Screen.width * 0.08f, Screen.height * 0.1f, Screen.width * 0.5f, Screen.height * 0.65f), "Mod Shop", modShopBoxStyle);
    }
    
    void MoneySensorBox()
    {
        GUIStyle moneySensorBoxStyle = new GUIStyle(GUI.skin.box);
        moneySensorBoxStyle.fontSize = Screen.width / 26;
        moneySensorBoxStyle.normal.background = myGuiTexture;
        GUIStyle moneySensorTextStyle = new GUIStyle(GUI.skin.box);
        moneySensorTextStyle.fontSize = Screen.width / 42;
        moneySensorTextStyle.normal.textColor = Color.green;
        GUI.Box(new Rect(Screen.width * 0.12f, Screen.height * 0.25f, Screen.width * 0.42f, Screen.height * 0.21f), "Money Sensor", moneySensorBoxStyle);
        GUI.Box(new Rect(Screen.width * 0.12f, Screen.height * 0.32f, Screen.width * 0.42f, Screen.height * 0.14f), moneySensorString, moneySensorTextStyle);
    }
    
    void InfraredScannerBox()
    {
        GUIStyle infraredScannerBoxStyle = new GUIStyle(GUI.skin.box);
        infraredScannerBoxStyle.fontSize = Screen.width / 26;
        infraredScannerBoxStyle.normal.background = myGuiTexture;
        GUIStyle infraredScannerTextStyle = new GUIStyle(GUI.skin.box);
        infraredScannerTextStyle.fontSize = Screen.width / 42;
        infraredScannerTextStyle.normal.textColor = Color.green;
        GUI.Box(new Rect(Screen.width * 0.12f, Screen.height * 0.5f, Screen.width * 0.42f, Screen.height * 0.21f), "Infrared Scanner", infraredScannerBoxStyle);
        GUI.Box(new Rect(Screen.width * 0.12f, Screen.height * 0.57f, Screen.width * 0.42f, Screen.height * 0.14f), infraredScannerString, infraredScannerTextStyle);
    }
    
    void BuyOneButton()
    {
        GUIStyle buttonStyle = new GUIStyle (GUI.skin.button);
        buttonStyle.fontSize = Screen.width/28;
        buttonStyle.normal.textColor = Color.green;
        buttonStyle.normal.background = myGuiTexture;
        
        buyOneBtn = GUI.Button(new Rect(Screen.width * 0.58f, Screen.height * 0.25f, Screen.width * 0.2f, Screen.height * 0.2f), "Buy", buttonStyle);
        if (buyOneBtn)
        {
            if (GameManager.instance.haveMoneySensor == false && currentMoney >= 2)
            {
                GameManager.instance.haveMoneySensor = true;
                GameManager.instance.Money -= 2;
            }
        }
    }
    
    void BuyTwoButton()
    {
        GUIStyle buttonStyle = new GUIStyle (GUI.skin.button);
        buttonStyle.fontSize = Screen.width/28;
        buttonStyle.normal.textColor = Color.green;
        buttonStyle.normal.background = myGuiTexture;
        buyTwoBtn = GUI.Button(new Rect(Screen.width * 0.58f, Screen.height * 0.5f, Screen.width * 0.2f, Screen.height * 0.2f), "Buy", buttonStyle);
        if (buyTwoBtn)
        {
            if (GameManager.instance.haveInfraredScanner == false && currentMoney >= 3)
            {
                GameManager.instance.haveInfraredScanner = true;
                GameManager.instance.Money -= 3;
            }
        }
    }
    
    void EquipOneButton()
    {
        GUIStyle buttonStyle = new GUIStyle (GUI.skin.button);
        buttonStyle.fontSize = Screen.width/28;
        buttonStyle.normal.textColor = Color.green;
        buttonStyle.normal.background = myGuiTexture;
        
        equipOneBtn = GUI.Button(new Rect(Screen.width * 0.78f, Screen.height * 0.25f, Screen.width * 0.2f, Screen.height * 0.2f), "Equip", buttonStyle);
        if (equipOneBtn)
        {
            if (GameManager.instance.haveMoneySensor == true)
            {
                GameManager.instance.haveInfraredScannerEquip = false;
                GameManager.instance.haveMoneySensorEquip = true;
            }
        }
    }
    
    void EquipTwoButton()
    {
        GUIStyle buttonStyle = new GUIStyle (GUI.skin.button);
        buttonStyle.fontSize = Screen.width/28;
        buttonStyle.normal.textColor = Color.green;
        buttonStyle.normal.background = myGuiTexture;
        
        equipTwoBtn = GUI.Button(new Rect(Screen.width * 0.78f, Screen.height * 0.5f, Screen.width * 0.2f, Screen.height * 0.2f), "Equip", buttonStyle);
        if (equipTwoBtn)
        {
            if (GameManager.instance.haveInfraredScanner == true)
            {
                GameManager.instance.haveMoneySensorEquip = false;
                GameManager.instance.haveInfraredScannerEquip = true;
            }
        }
    }
    
    void EquippedLabel()
    {
        GUIStyle equipBoxStyle = new GUIStyle(GUI.skin.box);
        equipBoxStyle.fontSize = 24;
        equipBoxStyle.normal.background = myGuiTexture;
        equipBoxStyle.normal.textColor = Color.green;
       // GUIStyle moneySensorTextStyle = new GUIStyle(GUI.skin.box);
       // moneySensorTextStyle.fontSize = 14;
        GUI.Box(new Rect(Screen.width * 0.12f, Screen.height * 0.8f, Screen.width * 0.45f, Screen.height * 0.1f), "Equipped: " + whatIsEquipped, equipBoxStyle);
       // GUI.Box(new Rect(Screen.width * 0.12f, Screen.height * 0.32f, Screen.width * 0.42f, Screen.height * 0.14f), moneySensorString, moneySensorTextStyle);
        //if haveMoneySensorEquip == true, then display
        
        //if haveInfraredScannerEquip == true then display
    }
    
    void EquipUpdateMethod()
    {
        if (GameManager.instance.haveMoneySensorEquip == true)
        {
            whatIsEquipped = "Money Sensor";
        }
        else if (GameManager.instance.haveInfraredScannerEquip == true)
        {
            whatIsEquipped = "Infrared Scanner";
        }
        else if (GameManager.instance.haveMoneySensor == false && GameManager.instance.haveInfraredScanner == false)
        {
            whatIsEquipped = "nothing";
        }
    }
    
    void CurrentMoneyLabel()
    {
        GUIStyle moneyStyle = new GUIStyle(GUI.skin.label);
        //moneyStyle.normal.textColor = Color.green;
        moneyStyle.fontSize = Screen.width / 42;
        GUI.Label(new Rect(Screen.width * 0.7f, Screen.height * 0.1f, Screen.width * 0.2f, Screen.height * 0.1f), "You have " + currentMoney + " dollars to spend.", moneyStyle);
    }
    
    void NextLvlButton()
    {
        GUIStyle buttonStyle = new GUIStyle (GUI.skin.button);
        buttonStyle.fontSize = Screen.width/28;
        buttonStyle.normal.textColor = Color.green;
        buttonStyle.normal.background = myGuiTexture;
        
        nextLvlBtn = GUI.Button(new Rect(Screen.width * 0.58f, Screen.height * 0.7f, Screen.width * 0.2f, Screen.height * 0.2f), "Next Level", buttonStyle);
        if (nextLvlBtn)
        {
            GameManager.instance.proxE = 0;
            GameManager.instance.proxN = 0;
            GameManager.instance.proxS = 0;
            GameManager.instance.proxW = 0;
            SceneManager.LoadScene(GameManager.instance.LevelInt);
        }
    }
    
}

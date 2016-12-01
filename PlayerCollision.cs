using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerCollision : MoveTest2 {

    private bool showGameOver;
    
    private float timeLeft;
    
    //SOUNDS
    public AudioClip mineCollision;
    public AudioClip winJingle;
    public AudioClip moneyGet;
    
   //private Animator animatorMoney;
    //GameObject moneyObject;
    
    void Start()
    {
        //moneyObject = GameObject.Find("Money");
        //animatorMoney = moneyObject.GetComponent<Animator>();
    }

	private void OnTriggerEnter2D(Collider2D other) //the 2D must be capitalized D
	{
        if (other.tag == "Hidden Tile")
        {
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Goal")
        {
            SoundManager.instance.efxSource.clip = winJingle;
            SoundManager.instance.efxSource.Play();
           
            StartCoroutine(WaitandPause2(2.25f));    
            //LOAD MOD SHOP MENU SCENE
            Debug.Log("You Hacked the Mainframe!");
        }
        else if (other.tag == "Enemy")
        {
            Debug.Log("You died");
            SoundManager.instance.efxSource.clip = mineCollision;
            SoundManager.instance.efxSource.Play();
            //PAUSE PHYSICS
            StartCoroutine(WaitandPause(.25f));
            //Time.timeScale = 0;
            //BRING UP - Game Over. Retry. BUTTONS
        }
        else if (other.tag == "Item")
        {
            SoundManager.instance.efxSource.clip = moneyGet;
            SoundManager.instance.efxSource.Play();
            GameManager.instance.Money += 1;
            //animatorMoney.Play("Money-Anim");
            // other.gameObject.SetActive(false);
        }
        else if (other.tag == "FinalGoal")
        {
            SoundManager.instance.efxSource.clip = winJingle;
            SoundManager.instance.efxSource.Play();
            StartCoroutine(WaitandPauseWIN(2.25f));
        }
	}
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "ProxN")
        {
            //Debug.Log("in proximity");
            GameManager.instance.proxN = 1;
            //GameManager.instance.mineDetected = true;
            //StartCoroutine(ProximityCount());
            //GameManager.instance.mineDetected = false;
            //mineSensor += 1;
        }
        else if (other.tag == "ProxE")
        {
            GameManager.instance.proxE = 1;
        }
        else if (other.tag == "ProxS")
        {
            GameManager.instance.proxS = 1;
        }
        else if (other.tag == "ProxW")
        {
            GameManager.instance.proxW = 1;
        } 
        
        //MONEY SENSOR MOD
        else if (GameManager.instance.haveMoneySensorEquip == true && other.tag == "MoneyProxN")
        {
            GameManager.instance.moneyProxN = 1;           
        }
        else if (GameManager.instance.haveMoneySensorEquip == true && other.tag == "MoneyProxE")
        {
            GameManager.instance.moneyProxE = 1;           
        }
        else if (GameManager.instance.haveMoneySensorEquip == true && other.tag == "MoneyProxS")
        {
            GameManager.instance.moneyProxS = 1;           
        }
        else if (GameManager.instance.haveMoneySensorEquip == true && other.tag == "MoneyProxW")
        {
            GameManager.instance.moneyProxW = 1;           
        }   
    }
    

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "ProxN")
		{
			GameManager.instance.proxN = 0;
		}
		else if (other.tag == "ProxE")
		{
			GameManager.instance.proxE = 0;
		}
		else if (other.tag == "ProxS")
		{
			GameManager.instance.proxS = 0;
		}
		else if (other.tag == "ProxW")
		{
			GameManager.instance.proxW = 0;
		}
        else if (GameManager.instance.haveMoneySensorEquip == true && other.tag == "MoneyProxN")
        {
            GameManager.instance.moneyProxN = 0;           
        }
        else if (GameManager.instance.haveMoneySensorEquip == true && other.tag == "MoneyProxE")
        {
            GameManager.instance.moneyProxE = 0;           
        }
        else if (GameManager.instance.haveMoneySensorEquip == true && other.tag == "MoneyProxS")
        {
            GameManager.instance.moneyProxS = 0;           
        }
        else if (GameManager.instance.haveMoneySensorEquip == true && other.tag == "MoneyProxW")
        {
            GameManager.instance.moneyProxW = 0;           
        }
        
	}
    
   
   
		




    IEnumerator WaitandPause(float waitTime)
    {
        //Debug.Log("logged");
        yield return new WaitForSeconds(waitTime);
        Time.timeScale = 0;
        GameManager.instance.showGameOver = true;
    }
    
    IEnumerator WaitandPauseWIN(float waitTime)
    {
        //Debug.Log("logged");
        yield return new WaitForSeconds(waitTime);
        Time.timeScale = 0;
        GameManager.instance.showVictory = true;
    }

    IEnumerator WaitandPauseBasic(float waitTime)
    {
        //Debug.Log("logged");
        yield return new WaitForSeconds(waitTime);     
    }

    IEnumerator WaitandPause2(float waitTime)
    {
        timeLeft = waitTime;
        Time.timeScale = 0;
        while (waitTime > 0)
        {
            Debug.Log(waitTime--);
            yield return new WaitForSecondsRealtime(1f);
            timeLeft = waitTime;
        }
        GameManager.instance.LevelInt += 1;       
        GameManager.instance.proxE = 0;        
        GameManager.instance.proxW = 0;        
        GameManager.instance.proxN = 0;        
        GameManager.instance.proxS = 0;           
        Time.timeScale = 1;        
        SceneManager.LoadScene("PostLvlScene");
    }

     


}

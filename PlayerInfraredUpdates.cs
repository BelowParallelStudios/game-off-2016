using UnityEngine;
using System.Collections;

public class PlayerInfraredUpdates : MonoBehaviour {

    SpriteRenderer thisSpriteRenderer;
    BoxCollider2D thisBoxCollider;
    
    private bool isEmpty;
    private bool working;
    
    
    void Start()
    {
        thisSpriteRenderer = this.transform.gameObject.GetComponent<SpriteRenderer>();
        thisBoxCollider = this.transform.gameObject.GetComponent<BoxCollider2D>();
    }
   
    void FixedUpdate()
    {
            isEmpty = true;
            NothingMethod();
    }
    
    void Update()
    {
        //Debug.Log(working);
        if (GameManager.instance.haveInfraredScannerEquip == true)
        {
            EnableScript();
            DisableScript();
        }       
       
    }
    void EnableScript()
    {
        if (this.gameObject.name == "InfraredN" && GameManager.instance.lastMove == "up")
        {
            thisSpriteRenderer.enabled = true;
            thisBoxCollider.enabled = true;                   
        }
        else if (this.gameObject.name == "InfraredE" && GameManager.instance.lastMove == "right")
        {
            thisSpriteRenderer.enabled = true;
            thisBoxCollider.enabled = true;                   
        }
        else if (this.gameObject.name == "InfraredS" && GameManager.instance.lastMove == "down")
        {
            thisSpriteRenderer.enabled = true;
            thisBoxCollider.enabled = true;                   
        }
        else if (this.gameObject.name == "InfraredW" && GameManager.instance.lastMove == "left")
        {
            thisSpriteRenderer.enabled = true;          
            thisBoxCollider.enabled = true;      
        }            
    }
    void DisableScript()
    {
        if (this.gameObject.name == "InfraredN" && GameManager.instance.lastMove != "up")
        {
            thisSpriteRenderer.enabled = false;
            thisBoxCollider.enabled = false;                   
        }
        else if (this.gameObject.name == "InfraredE" && GameManager.instance.lastMove != "right")
        {
            thisSpriteRenderer.enabled = false;
            thisBoxCollider.enabled = false;                   
        }
        else if (this.gameObject.name == "InfraredS" && GameManager.instance.lastMove != "down")
        {
            thisSpriteRenderer.enabled = false;
            thisBoxCollider.enabled = false;                   
        }
        else if (this.gameObject.name == "InfraredW" && GameManager.instance.lastMove != "left")
        {
            thisSpriteRenderer.enabled = false;
            thisBoxCollider.enabled = false;                   
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.tag == "Goal")
        {
            isEmpty = false;
            GameManager.instance.infraredScannerString = "Mainframe";
        }
        else if (other.tag == "Item")
        {
            isEmpty = false;
            GameManager.instance.infraredScannerString = "Money";
        }
        else if (other.tag == "Enemy")
        {           
            Debug.Log("this is happening!!!!");
            isEmpty = false;
            GameManager.instance.infraredScannerString = "Mine";
        }
        //else if (other.tag != "Goal" && other.tag != "Item" && other.tag != "Enemy")
       // {
        //    GameManager.instance.infraredScannerString = "nothing";
       // }
        //else GameManager.instance.infraredScannerString = "nothing";
    }
    
    /*private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Goal")
        {
            //isEmpty = true;
            GameManager.instance.infraredScannerString = "nothing";
        }
        else if (other.tag == "Item")
        {
            //isEmpty = true;
            GameManager.instance.infraredScannerString = "nothing";
        }
        else if (other.tag == "Enemy")
        {
            // isEmpty = true;
            GameManager.instance.infraredScannerString = "nothing";
        }
    }*/
    
    private void NothingMethod()
    {
        if (isEmpty == true)
        {
            GameManager.instance.infraredScannerString = "nothing";
        }
    }
}

using UnityEngine;
using System.Collections;

public class AnimationMoney : MonoBehaviour {

    Animator moneyAnim;
    SpriteRenderer moneySprite;
    
    void Start()
    {
        moneySprite = this.transform.gameObject.GetComponent<SpriteRenderer>();
        moneyAnim = this.transform.gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            moneySprite.enabled = true;
            //moneyAnim.Play("Money-Anim");
            StartCoroutine(Wait());
           // this.gameObject.SetActive(false);

        }
    }
    
    IEnumerator Wait()
    {
        Debug.Log("logged");
        yield return new WaitForSeconds(.35f);
        this.gameObject.SetActive(false);
        //this.gameObject.SetActive(false);
    }
    
}

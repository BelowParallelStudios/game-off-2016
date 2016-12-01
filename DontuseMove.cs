using UnityEngine;
using System.Collections;

public class DontuseMove : MonoBehaviour {

    public LayerMask blockingLayer;         //Layer on which collision will be checked.
    private BoxCollider2D boxCollider;      //The BoxCollider2D component attached to this object.
    private Rigidbody2D rb2D;               //The Rigidbody2D component attached to this object.

    public Vector2 playerPos;

    private int speed;



    // Use this for initialization
    protected virtual void Start () {

        speed = 3;

        //Get a component reference to this object's BoxCollider2D
        boxCollider = GetComponent <BoxCollider2D> ();

        //Get a component reference to this object's Rigidbody2D
        rb2D = GetComponent <Rigidbody2D> ();

        Vector2 playerPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate () {

        Vector2 mvec = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

        rb2D.MovePosition (rb2D.position + mvec * (speed * Time.deltaTime));
        
}
}

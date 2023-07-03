using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Variables
    public Rigidbody2D theRB;
    public float moveSpeed;
    
    public Animator myAnim;
    
    public static PlayerController instance; // Reference to PlayerController script in the inspector
    
    public string areaTransitionName;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            if (instance != this) Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the player
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;

        // Initiate player animation when walking
        myAnim.SetFloat("moveX", theRB.velocity.x);
        myAnim.SetFloat("moveY", theRB.velocity.y);

        // Saves animation when player stops moving (idle)
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    public void SetBounds(Vector3 bottomLeft, Vector3 topRight)
    {
        bottomLeftLimit = bottomLeft + new Vector3(1f, 1.3f, 0f);
        topRightLimit = topRight + new Vector3(-1f, -1.3f, 0f);
    }
}
    
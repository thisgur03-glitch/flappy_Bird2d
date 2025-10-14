using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public LogicScript logicScript;
    private Rigidbody2D rigidbody2D;
    private bool isGrounded;
    public float jumpForce = 20f;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive == true){
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        logicScript.gameOver();
        birdIsAlive = false;
    }
}

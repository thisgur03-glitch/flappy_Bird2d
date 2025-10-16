using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public LogicScript logicScript;
    private Rigidbody2D rigidbody2D;
    public float jumpForce = 20f;
    public bool birdIsAlive = true;

    [Header("Wing Sprites")]
    public GameObject wingDown;
    public GameObject wingUp;

    private bool isWingUp = false;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        SetWingState(false); // Start with down wing
    }

    void Update()
    {
        if (!birdIsAlive) return;

        // Jump if Spacebar pressed, mouse clicked, or screen tapped
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
            SetWingState(true);
        }

        // Return wing to down when key/tap is released
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            SetWingState(false);
        }

        // Optional: handle mobile touch separately
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Jump();
            SetWingState(true);
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            SetWingState(false);
        }
    }

    void Jump()
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.gameOver();
        birdIsAlive = false;
    }

    void SetWingState(bool up)
    {
        isWingUp = up;
        wingUp.SetActive(up);
        wingDown.SetActive(!up);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 5;
    public bool jump;
    public float jumpSpeed = 6;
    public float jumpHeight = 3;
    public bool health;
    public int maxHealth = 10;

    public Vector3 directionX = new Vector3 (1, 0, 0);
    public Vector3 directionY = new Vector3(0, 1, 0);
    public int playerHealth;
    Controller controller;

    bool jumpStart = false;
    bool jumpUp = false;
    bool jumpDown = false;
    bool jumpReset = false;
    float jumpMax;
    float currentYPosition;
    int damage;
    // Start is called before the first frame update
    void Start()
    {
        jumpMax = currentYPosition + jumpHeight;
        currentYPosition = transform.position.y;

        controller = this;
    }

    // Update is called once per frame
    void Update()
    {
        // Setting Players Position
        if (currentYPosition != transform.position.y && jumpStart == false)
        {
            currentYPosition = transform.position.y;
            jumpMax = currentYPosition + 5;
        }

        // Horiziontal Movement
        if (jumpStart == false)
        {
            this.transform.position += directionX * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        }

        // Jumping
        if (jump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpStart = true;
                jumpUp = true;
            }

            if (jumpStart == true)
            {
                if (jumpUp == true)
                {
                    if (transform.position.y < jumpMax)
                    {
                        this.transform.position += directionY * jumpSpeed * Time.deltaTime;
                    }
                    else
                    {
                        jumpDown = true;
                        jumpUp = false;
                    }
                }

                if (jumpDown == true)
                {
                    if (transform.position.y > currentYPosition)
                    {
                        this.transform.position -= directionY * jumpSpeed * Time.deltaTime;
                    }
                    else
                    {
                        jumpReset = true;
                        jumpDown = false;
                    }
                }
            }

            if (jumpReset == true)
            {
                currentYPosition = transform.position.y;
                jumpStart = false;
                jumpReset = false;
            }
        }

        //Health
        if (health == true)
        {
            playerHealth = maxHealth - damage;
        }
    }
}

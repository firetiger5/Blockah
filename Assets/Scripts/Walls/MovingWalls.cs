using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWalls : MonoBehaviour
{
    //Variable Initialization/Declaration
    public float speed;
    public bool isX = true; //If this stays X then it will move on the x-axis, else it moves on the y
    public int dir = 0; //Used to determine which way to start moving, 0 is true
    public bool canMove = true;
    private Rigidbody2D rigid2D;

    //Function to stop movment because of pause or win condition
    public void EnemyFreeze()
    {
        if (canMove)
        {
            rigid2D.velocity = new Vector2(0f, 0f);
            canMove = false;
        }

        else
            canMove = true;
    }

    //Start is called at the beginning of the game
    private void Start()
    {
        //If stataement to change the speed based on the direction
        if (dir == 1)
            speed = -speed;

        //Sets up this rigidbody component
        rigid2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
            return;

        //If statment to check if X-axis is moving or not
        if(isX)
        {
            //Moves in the x-axis toward a wall
            rigid2D.velocity = new Vector2(speed, 0f);
        }

        else
        {
            //Moves in the y-axis toward a wall
            rigid2D.velocity = new Vector2(0f, speed);
        }
    }

    //Once the mover collides with a wall it should switch directions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            //Makes sure the mover stops moving
            rigid2D.velocity = new Vector2(0f, 0f);

            //Switches direction
            speed = -speed;
        }
    }
}

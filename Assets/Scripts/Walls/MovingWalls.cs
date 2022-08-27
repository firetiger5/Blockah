using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWalls : MonoBehaviour
{
    //Variable Initialization/Declaration
    public float speed = 2.5f;
    public bool isX = true; //If this stays X then it will move on the x-axis, else it moves on the y
    private int isUpLeft = 0; //Used to determine which way to start moving, 0 is true

    //Start is called at the beginning of the game
    private void Start()
    {
        //Randomize which direction it starts moving!
        isUpLeft = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        //If statment to check if X-axis is moving or not
        if(isX)
        {
            //addX = Mathf.PingPong(Time.time * speed, Distance);
            //transform.position = new Vector2(startX + addX, transform.position.y);
        }

        else
        {
            //addY = Mathf.PingPong(Time.time * speed, Distance);
            //transform.position = new Vector2(transform.position.x, startY + addY);
        }
    }
}

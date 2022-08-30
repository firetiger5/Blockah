using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variable Implementation/Declaration
    public Rigidbody2D PlayerRG;
    public float startSpeed;
    public float maxSpeed;
    public float acceleration;
    private float originalSpeed;


    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = startSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Space was pressed!");

            if (startSpeed > 0f)
                startSpeed = 0f;

            else
                startSpeed = originalSpeed;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            if (startSpeed < maxSpeed)
                startSpeed = startSpeed + (acceleration * Time.deltaTime);
            
            PlayerRG.velocity = new Vector2(startSpeed, 0f);
        }

        else if (Input.GetAxis("Horizontal") < 0)
        {
            if (startSpeed < maxSpeed)
                startSpeed = startSpeed + (acceleration * Time.deltaTime);

            PlayerRG.velocity = new Vector2(-startSpeed, 0f);
        }

        else if (Input.GetAxis("Vertical") > 0)
        {
            if (startSpeed < maxSpeed)
                startSpeed = startSpeed + (acceleration * Time.deltaTime);

            PlayerRG.velocity = new Vector2(0f, startSpeed);
        }

        else if (Input.GetAxis("Vertical") < 0)
        {
            if (startSpeed < maxSpeed)
                startSpeed = startSpeed + (acceleration * Time.deltaTime);

            PlayerRG.velocity = new Vector2(0f, -startSpeed);
        }

        else if (Input.GetAxis("Horizontal") == 0 & Input.GetAxis("Vertical") == 0)
        {
            if (startSpeed != originalSpeed)
                startSpeed = originalSpeed;

            PlayerRG.velocity = new Vector2(0f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Win")
        {
            Debug.Log("WINNER!");
        }
    }
}

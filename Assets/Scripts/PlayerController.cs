using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variable Implementation/Declaration
    
    //Public
    public Rigidbody2D PlayerRG;
    public float startSpeed;
    public float maxSpeed;
    public float acceleration;
    public GameObject WonUI;
    public GameObject PauseUI;

    //Private
    private float originalSpeed;
    private bool canMove = true;
    private GameObject[] enemies;


    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = startSpeed;

        enemies = GameObject.FindGameObjectsWithTag("Mover");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (canMove)
            {
                canMove = false; 
                PlayerRG.velocity = new Vector2(0f, 0f);

                foreach (GameObject enemy in enemies)
                    enemy.GetComponent<MovingWalls>().EnemyFreeze();

                PauseUI.SetActive(true);
            }

            else
            {
                foreach (GameObject enemy in enemies)
                    enemy.GetComponent<MovingWalls>().EnemyFreeze();

                PauseUI.SetActive(false);
                canMove = true;
            }
        }

        if (!canMove)
            return;

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
            canMove = false;
            PlayerRG.velocity = new Vector2(0f, 0f);

            foreach (GameObject enemy in enemies)
                enemy.GetComponent<MovingWalls>().EnemyFreeze();

            WonUI.SetActive(true);
        }
    }
}

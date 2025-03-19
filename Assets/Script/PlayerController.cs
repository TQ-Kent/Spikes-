using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject Object;
    public GameObject gameController;

    private Vector2 newPos;

    private Animator anim;

    private float JumpPower;
    private float minX;
    private float maxX;
    // Start is called before the first frame update
    void Start()
    {
        Object = gameObject;
        anim = Object.GetComponent<Animator>();
        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
        JumpPower = 400;
        minX = -8.35f;
        maxX = 8.35f;

        newPos.x = Object.transform.position.x;
        newPos.y = Object.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left") || Input.GetKey("a"))
        {


            newPos.x = Object.transform.position.x - 1;
            newPos.y = Object.transform.position.y;

            if (Object.transform.position.x - 1 >= minX)
            {
                Object.transform.position = Vector2.Lerp(Object.transform.position, newPos, 2 * Time.deltaTime * 5);
            }

            if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
            {
                anim.SetBool("isGround", false);
                Object.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpPower));
            }

            if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
            {
                Object.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -JumpPower));
            }
        }
        else if (Input.GetKey("right") || Input.GetKey("d"))
        {
            newPos.x = Object.transform.position.x + 1;
            newPos.y = Object.transform.position.y;

            if (Object.transform.position.x + 1 <= maxX)
            {
                Object.transform.position = Vector2.Lerp(Object.transform.position, newPos, 2 * Time.deltaTime * 5);
            }

            if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
            {
                anim.SetBool("isGround", false);
                Object.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpPower));
            }

            if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
            {
                Object.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -JumpPower));
            }
        }
        else if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
        {
            anim.SetBool("isGround", false);
            Object.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpPower));
        }
        else if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
        {
            Object.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -JumpPower));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Spike"))
        {
            gameController.GetComponent<GameController>().Endgame();
        }
        else if (collision.gameObject.tag.Equals("Surface"))
        {
            anim.SetBool("isGround", true);
        }
    }
}

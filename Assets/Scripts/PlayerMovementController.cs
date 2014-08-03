using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour 
{


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            MoveRight();
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            MoveLeft();
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            MoveDown();
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            MoveUp();
        }

        CapVelocity();

	}

    private void CapVelocity()
    {
        // no rotation
        this.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (this.GetComponent<Rigidbody2D>().velocity.SqrMagnitude() >= GameProperties.PlayerMaxVelocity * GameProperties.PlayerMaxVelocity)
        {
            this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity.normalized * GameProperties.PlayerMaxVelocity;
        }



        //if(this.GetComponent<Rigidbody2D>().velocity.x >= GameProperties.PlayerMaxVelocity)
        //{
        //    this.GetComponent<Rigidbody2D>().velocity = new Vector2(GameProperties.PlayerMaxVelocity, 0);
        //    //Debug.Log("Capping");
        //}
        //else if (this.GetComponent<Rigidbody2D>().velocity.x <= -GameProperties.PlayerMaxVelocity)
        //{
        //    this.GetComponent<Rigidbody2D>().velocity = new Vector2(-GameProperties.PlayerMaxVelocity, 0);
        //    //Debug.Log("Capping");
        //}

        //if (this.GetComponent<Rigidbody2D>().velocity.y >= GameProperties.PlayerMaxVelocity)
        //{
        //    this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, GameProperties.PlayerMaxVelocity);
        //    //Debug.Log("Capping");
        //}
        //else if (this.GetComponent<Rigidbody2D>().velocity.y <= -GameProperties.PlayerMaxVelocity)
        //{
        //    this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -GameProperties.PlayerMaxVelocity);
        //    //Debug.Log("Capping");
        //}
        //Debug.Log(this.GetComponent<Rigidbody2D>().velocity);
    }

    private void MoveUp()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -GameProperties.PlayerMoveForce));
    }

    private void MoveDown()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, GameProperties.PlayerMoveForce));
    }

    private void MoveRight()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2( GameProperties.PlayerMoveForce, 0));
    }

    private void MoveLeft()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-GameProperties.PlayerMoveForce, 0));
    }
}

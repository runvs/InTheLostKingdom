using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour {
    


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

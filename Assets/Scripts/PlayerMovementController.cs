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
	}

    private void MoveRight()
    {
        this.transform.position = new Vector3(this.transform.position.x + 0.25f, this.transform.position.y);
    }

    private void MoveLeft()
    {
        this.transform.position = new Vector3(this.transform.position.x - 0.25f, this.transform.position.y);
    }
}

using UnityEngine;

public enum Direction
{
    NORTH, EAST, SOUTH, WEST
}

public class PlayerMovementController : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
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

        //Debug.Log(this.GetComponent<Rigidbody2D>().velocity);
    }

    private void MoveUp()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -GameProperties.PlayerMoveForce));
        this.PlayerDirection = Direction.NORTH;
    }

    private void MoveDown()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, GameProperties.PlayerMoveForce));
        this.PlayerDirection = Direction.SOUTH;
    }

    private void MoveRight()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(GameProperties.PlayerMoveForce, 0));
        this.PlayerDirection = Direction.EAST;
    }

    private void MoveLeft()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-GameProperties.PlayerMoveForce, 0));
        this.PlayerDirection = Direction.WEST;
    }
}

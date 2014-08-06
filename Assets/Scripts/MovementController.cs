using UnityEngine;

public enum Direction
{
    NORTH, EAST, SOUTH, WEST
}

public class MovementController : MonoBehaviour
{
    public Direction Direction;
    private float _force;

    void Start()
    {
        if (this.tag == "Player")
        {
            _force = GameProperties.PlayerMoveForce;
        }
        else
        {
            _force = GameProperties.EnemyMoveForce;
        }
    }

    void Awake()
    {
        if (this.tag == "Player")
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        if (this.tag == "Player")
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
        }
    }

    public void CapVelocity()
    {
        // no rotation
        this.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (this.GetComponent<Rigidbody2D>().velocity.SqrMagnitude() >= GameProperties.PlayerMaxVelocity * GameProperties.PlayerMaxVelocity)
        {
            this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity.normalized * GameProperties.PlayerMaxVelocity;
        }

        //Debug.Log(this.GetComponent<Rigidbody2D>().velocity);
    }

    public void MoveUp()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -GameProperties.PlayerMoveForce));
        this.Direction = Direction.NORTH;
    }

    public void MoveDown()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, GameProperties.PlayerMoveForce));
        this.Direction = Direction.SOUTH;
    }

    public void MoveRight()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(GameProperties.PlayerMoveForce, 0));
        this.Direction = Direction.EAST;
    }

    public void MoveLeft()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-GameProperties.PlayerMoveForce, 0));
        this.Direction = Direction.WEST;
    }
}

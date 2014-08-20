using UnityEngine;

public enum Direction
{
    NORTH, EAST, SOUTH, WEST
}

public class MovementController : MonoBehaviour
{
    public Direction Direction;
    private float _force;

    public Sprite _leftSprite;
    public Sprite _rightSprite;
    public Sprite _upSprite;
    public Sprite _downSprite;

    public GameObject WalkDust;

    private float _timeSinceLastWalkDust;


    void Start()
    {
        _timeSinceLastWalkDust = 0.0f;
        if (this.tag == "Player")
        {
            _force = GameProperties.PlayerMoveForce;
        }
        else if (this.tag == "Enemies")
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
        _timeSinceLastWalkDust -= Time.deltaTime;
        if (this.tag == "Player")
        {
            if (GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>().PlayerCanMove())
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    MoveRight();
                    
                }
                else if (Input.GetAxis("Horizontal") < 0)
                {
                    MoveLeft();
                }

                if (Input.GetAxis("Vertical") < 0)
                {
                    MoveDown();
                }
                else if (Input.GetAxis("Vertical") > 0)
                {
                    MoveUp();
                }
             
            }
        }
    }

    private void SpawnWalkDust()
    {
        if (_timeSinceLastWalkDust <= 0)
        {
            //Instantiate(WalkDust, this.transform.position, this.transform.rotation);
            _timeSinceLastWalkDust += Random.Range(0.5f, 0.75f);
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
        //this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, _force));
        this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity + new Vector2(0, _force*0.02f);
        this.Direction = Direction.NORTH;
        this.GetComponent<SpriteRenderer>().sprite = _upSprite;
        SpawnWalkDust();
    }

    public void MoveDown()
    {
        //this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -_force));
        this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity + new Vector2(0, -_force*0.02f);
        this.Direction = Direction.SOUTH;
        this.GetComponent<SpriteRenderer>().sprite = _downSprite;
        SpawnWalkDust();
    }

    public void MoveRight()
    {
        //this.GetComponent<Rigidbody2D>().AddForce(new Vector2(_force, 0));
        this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity + new Vector2(_force * 0.02f, 0);
        this.Direction = Direction.EAST;
        this.GetComponent<SpriteRenderer>().sprite = _rightSprite;
        SpawnWalkDust();
    }


    public void MoveLeft()
    {
        //this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-_force, 0));
        this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity + new Vector2(-_force * 0.02f, 0);
        this.Direction = Direction.WEST;
        this.GetComponent<SpriteRenderer>().sprite = _leftSprite;
        SpawnWalkDust();
    }
}

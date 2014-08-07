using UnityEditor;
using UnityEngine;

public enum Direction
{
    NORTH, EAST, SOUTH, WEST
}

public class MovementController : MonoBehaviour
{
    public Direction Direction;
    private float _force;

    private Sprite _leftSprite;
    private Sprite _rightSprite;
    private Sprite _upSprite;
    private Sprite _downSprite;

    void Start()
    {
        if (this.tag == "Player")
        {
            _force = GameProperties.PlayerMoveForce;

            var sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath("Assets/Sprites/player.png");
            _downSprite = (Sprite)sprites[1];
            _upSprite = (Sprite)sprites[0];
            _rightSprite = (Sprite)sprites[2];
            _leftSprite = (Sprite)sprites[3];
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
                this.GetComponent<SpriteRenderer>().sprite = _rightSprite;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                MoveLeft();
                this.GetComponent<SpriteRenderer>().sprite = _leftSprite;
            }

            if (Input.GetAxis("Vertical") > 0)
            {
                MoveDown();
                this.GetComponent<SpriteRenderer>().sprite = _downSprite;
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                MoveUp();
                this.GetComponent<SpriteRenderer>().sprite = _upSprite;
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

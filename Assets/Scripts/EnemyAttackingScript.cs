using UnityEngine;

public class EnemyAttackingScript : MonoBehaviour
{
    GameObject _player;
    public float _inputTimer = 0.0f;
    public AudioClip AttackSound;
    public AudioClip HitSound;

    void Update()
    {
        if (_inputTimer <= 0.0f)
        {
            _inputTimer += GameProperties.BaseInputTimer * 4.0f;
            var direction = this.transform.parent.GetComponent<MovementController>().Direction;

            if (_player != null)
            {
                switch (direction)
                {
                    case Direction.NORTH:
                        _player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -GameProperties.EnemyKnockbackForce));
                        break;
                    case Direction.EAST:
                        _player.GetComponent<Rigidbody2D>().AddForce(new Vector2(GameProperties.EnemyKnockbackForce, 0));
                        break;
                    case Direction.SOUTH:
                        _player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, GameProperties.EnemyKnockbackForce));
                        break;
                    case Direction.WEST:
                        _player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-GameProperties.EnemyKnockbackForce, 0));
                        break;
                }

                _player.GetComponent<HealthController>().Health -= GameProperties.EnemyBaseDamage;
                audio.PlayOneShot(HitSound);
                GameObject.FindGameObjectWithTag("ScreenEffects").GetComponent<ScreenEffects>().ShakeScreen(0.35f, 1.0f);
                Debug.Log("Hit player!");
            }
        }

        if (_inputTimer > 0)
        {
            _inputTimer -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && _player == null)
        {
            Debug.Log("Set player");
            _player = coll.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && _player != null)
        {
            Debug.Log("Unset player");
            _player = null;
        }
    }
}

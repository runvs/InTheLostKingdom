using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingScript : MonoBehaviour
{
    List<GameObject> _enemies;
    public float _inputTimer = 0.0f;

    public AudioClip AttackSound;
    public AudioClip HitSound;

    void Start()
    {
        _enemies = new List<GameObject>();
    }

    void Update()
    {
        // check if there is a message present
        if (!GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>().TextMessagePresent) 
        {
            if (Input.GetButton("Fire1"))
            {
                if (_inputTimer <= 0.0f)
                {
                    bool hasHit = false;
                    _inputTimer += GameProperties.BaseInputTimer * 2.0f;
                    var playerDirection = this.transform.parent.GetComponent<MovementController>().Direction;

                    foreach (var enemy in _enemies)
                    {
                        if (enemy == null)
                            continue;

                        switch (playerDirection)
                        {
                            case Direction.NORTH:
                                enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, GameProperties.PlayerHitKnockbackForce));
                                break;
                            case Direction.EAST:
                                enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(GameProperties.PlayerHitKnockbackForce, 0));
                                break;
                            case Direction.SOUTH:
                                enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -GameProperties.PlayerHitKnockbackForce));
                                break;
                            case Direction.WEST:
                                enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(-GameProperties.PlayerHitKnockbackForce, 0));
                                break;
                        }

                        Debug.Log("Hit enemy!");
                        hasHit = true;
                        enemy.GetComponent<HealthController>().Health -= GameProperties.PlayerBaseDamage;

                        var enemyAttackingScript = enemy.transform.GetChild(0).GetComponent<EnemyAttackingScript>();
                        if (enemyAttackingScript != null)
                        {
                            enemyAttackingScript._inputTimer += 0.5f;
                        }
                        else
                        { 
                            Debug.Log("No AttackingScript on Enemy."); 
                        }
                    }
                    if (hasHit)
                    {
                        audio.PlayOneShot(HitSound);
                    }
                    else
                    {
                        audio.PlayOneShot(AttackSound);
                    }
                }
            }
        }

        if (_inputTimer > 0)
        {
            _inputTimer -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemies")
        {
            Debug.Log("Adding enemy");
            _enemies.Add(coll.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemies")
        {
            Debug.Log("Removing enemy");
            _enemies.Remove(coll.gameObject);
        }
    }
}

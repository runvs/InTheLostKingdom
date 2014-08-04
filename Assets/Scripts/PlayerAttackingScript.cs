﻿using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingScript : MonoBehaviour
{
    List<GameObject> _enemies;

    // Use this for initialization
    void Start()
    {
        _enemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            var playerDirection = this.transform.parent.GetComponent<PlayerMovementController>().PlayerDirection;

            foreach (var enemy in _enemies)
            {
                switch (playerDirection)
                {
                    case Direction.NORTH:
                        enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -GameProperties.EnemyKnockbackForce));
                        break;
                    case Direction.EAST:
                        enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(GameProperties.EnemyKnockbackForce, 0));
                        break;
                    case Direction.SOUTH:
                        enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, GameProperties.EnemyKnockbackForce));
                        break;
                    case Direction.WEST:
                        enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(-GameProperties.EnemyKnockbackForce, 0));
                        break;
                }

                Debug.Log("Hit enemy!");
            }
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

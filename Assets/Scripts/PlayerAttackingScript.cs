using System.Collections.Generic;
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
            if (_enemies.Count > 0)
            {
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

using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

    GameObject Player;
    public Vector3 Offset;

	// Use this for initialization
	void Start () 
    {
        DontDestroyOnLoad(gameObject);
        Player = GameObject.FindGameObjectWithTag("Player");
        if(Player == null)
        {
            throw new UnityException("Player could not be found.");
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10) + Offset;

	}
}

using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    GameObject Player;
    public Vector3 Offset;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player == null)
        {
            throw new UnityException("Player could not be found.");
        }
    }

    void Update()
    {
        this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10) + Offset;
    }
}

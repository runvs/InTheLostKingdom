using UnityEngine;
using System.Collections;

public class PlayerHitArea : MonoBehaviour {

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
        var playerDirection = this.transform.parent.gameObject.GetComponent<PlayerMovementController>().PlayerDirection;
        //var playerPosition = this.transform.parent.transform.po

        switch(playerDirection)
        {
            case Direction.NORTH:
                this.transform.localPosition = new Vector3(0, -1, 0);
                break;
            case Direction.EAST:
                this.transform.localPosition = new Vector3(1, 0, 0);
                break;
            case Direction.SOUTH:
                this.transform.localPosition = new Vector3(0, 1, 0);
                break;
            case Direction.WEST:
                this.transform.localPosition = new Vector3(-1, 0, 0);
                break;
        }
    }
}

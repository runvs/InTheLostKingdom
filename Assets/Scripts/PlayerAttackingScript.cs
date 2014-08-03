using UnityEngine;

public class PlayerAttackingScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            var playerDirection = this.gameObject.GetComponent<PlayerMovementController>().PlayerDirection;


        }
    }
}

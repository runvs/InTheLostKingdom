using UnityEngine;

public class TeleporterScript : MonoBehaviour
{

    public string TargetLevelName;

    public Vector2 TargetPosition;

    private bool isActive;

    private float remainingTimeUntilTeleport;


    // Use this for initialization
    void Start()
    {
        isActive = false;// for later
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            remainingTimeUntilTeleport -= Time.deltaTime;
            if (remainingTimeUntilTeleport <= 0)
            {
                Teleport();
            }
        }
    }

    private void Teleport()
    {
        Debug.Log("Teleporting!!");
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(TargetPosition.x, TargetPosition.y);
        Application.LoadLevel(TargetLevelName);
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Player hits Teleporter " + this.gameObject.name);
            Debug.Log("Player is teleporting to " + TargetLevelName + " on Position " + TargetPosition.ToString());
            StartFade();
        }
    }

    private void StartFade()
    {
        // TODO Fade Stuff
        isActive = true;
    }


    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isActive = true;
        }

    }

}

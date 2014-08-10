using UnityEngine;

public class TeleporterScript : MonoBehaviour
{
    public string TargetLevelName;
    public Vector2 TargetPosition;
    private SimpleAnimator _animator;
    private bool _isActive;
    private float _remainingTimeUntilTeleport = 0.0f;

    void Start()
    {
        _isActive = false;

        // Find animator
        var hudObjects = GameObject.FindGameObjectsWithTag("Hud");
        foreach (var hudObject in hudObjects)
        {
            if (hudObject.name == "Transition")
            {
                _animator = hudObject.GetComponent<SimpleAnimator>();
                _remainingTimeUntilTeleport = (_animator.TimePerFrame / 1000) * _animator.Sprites.Length;
                break;
            }
        }
    }

    void Update()
    {
        if (_isActive)
        {
            if (_remainingTimeUntilTeleport <= 0.0f)
            {
                Teleport();
            }
            else
            {
                _remainingTimeUntilTeleport -= Time.deltaTime;
            }
        }
    }

    public void Teleport()
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
        _isActive = true;
        _animator.RunAnimationOnce();
    }


    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            _isActive = true;
        }
    }
}

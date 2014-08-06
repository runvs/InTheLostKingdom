using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    GameObject _player;

    void Update()
    {
        if (_player != null)
        {
            var vector = _player.transform.position - this.transform.parent.parent.position;
            var angle = Mathf.Tan(vector.y / vector.x);

            var movementController = this.transform.parent.parent.GetComponent<MovementController>();

            if ((angle >= (7 * Mathf.PI / 4) && angle <= (2 * Mathf.PI)) || (angle >= 0.0f && angle <= (Mathf.PI / 4)))
            {
                movementController.MoveLeft();
            }
            else if (angle > (Mathf.PI / 4) && angle <= (3 * Mathf.PI / 4))
            {
                movementController.MoveUp();
            }
            else if (angle > (3 * Mathf.PI / 4) && angle <= (5 * Mathf.PI / 4))
            {
                movementController.MoveRight();
            }
            else
            {
                movementController.MoveDown();
            }

            movementController.CapVelocity();
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

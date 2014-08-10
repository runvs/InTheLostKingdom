using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    GameObject _player;

    void Update()
    {
        if (_player != null)
        {
            if (GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>().PlayerCanMove())
            {
                Vector3 vector = (_player.transform.position - this.transform.parent.parent.position);
                var angle = Mathf.Atan(vector.y / vector.x) + ((Mathf.Sign(vector.x) < 0) ? Mathf.PI : 0);  // calc angle by atan, note confinement of atan to [-90,90]
                // just in case, bend back angle to [0,360]
                while (angle > 2.0 * Mathf.PI)
                {
                    angle -= 2.0f * Mathf.PI;
                }
                var movementController = this.transform.parent.parent.GetComponent<MovementController>();

                if (angle >= 1.0 / 4.0 * Mathf.PI && angle < 3.0 / 4.0 * Mathf.PI)
                {
                    movementController.MoveUp();
                }
                else if (angle >= 3.0 / 4.0 * Mathf.PI && angle < 5.0 / 4.0 * Mathf.PI)
                {
                    movementController.MoveLeft();
                }
                else if (angle >= 5.0 / 4.0 * Mathf.PI && angle < 7.0 / 4.0 * Mathf.PI)
                {
                    movementController.MoveDown();
                }
                else
                {
                    movementController.MoveRight();
                }

                movementController.CapVelocity();
            }
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

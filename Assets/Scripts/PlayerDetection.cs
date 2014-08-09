using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    GameObject _player;

    void Update()
    {
        if (_player != null)
        {
            if (!GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>().TextMessagePresent)
            {
                Vector3  vector = (_player.transform.position - this.transform.parent.parent.position);
                var angle = Mathf.Atan(vector.y / vector.x) + ((Mathf.Sign(vector.x) < 0) ? Mathf.PI : 0);  // calc angle by atan, note confinement of atan to [-90,90]
                // just in case, bend back angle to [0,360]
                while(angle>2.0*Mathf.PI)
                {
                    angle -= 2.0f * Mathf.PI;
                }
                var movementController = this.transform.parent.parent.GetComponent<MovementController>();
                
                if (angle >= 1.0 / 4.0 * Mathf.PI && angle < 3.0 / 4.0 * Mathf.PI)
                {
                    movementController.MoveUp();
                    Debug.Log(vector.x + " " + vector.y + " " + angle + "Up");
                }
                else if (angle >= 3.0 / 4.0 * Mathf.PI && angle < 5.0 / 4.0 * Mathf.PI)
                {
                    movementController.MoveLeft();
                    Debug.Log(vector.x + " " + vector.y + " " + angle + "Left");
                }
                else if (angle >= 5.0 / 4.0 * Mathf.PI &&  angle < 7.0 / 4.0 * Mathf.PI)
                {
                    movementController.MoveDown();
                    Debug.Log(vector.x + " " + vector.y + " " + angle + "Down");
                }
                else
                {
                    movementController.MoveRight();
                    Debug.Log(vector.x + " " + vector.y + " " + angle + "Right");
                }


                //if ((angle >= (7.0 * Mathf.PI / 4.0) && angle <= (2.0 * Mathf.PI)) || (angle >= 0.0f && angle <= (Mathf.PI / 4.0)))
                //{
                //    movementController.MoveLeft();
                //}
                //else if (angle > (Mathf.PI / 4) && angle <= (3 * Mathf.PI / 4))
                //{
                //    movementController.MoveUp();
                //}
                //else if (angle > (3 * Mathf.PI / 4) && angle <= (5 * Mathf.PI / 4))
                //{
                //    movementController.MoveRight();
                //}
                //else
                //{
                //    movementController.MoveDown();
                //}

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

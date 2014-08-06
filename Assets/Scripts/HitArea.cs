using UnityEngine;

public class HitArea : MonoBehaviour
{
    void Update()
    {
        var direction = this.transform.parent.gameObject.GetComponent<MovementController>().Direction;

        switch (direction)
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

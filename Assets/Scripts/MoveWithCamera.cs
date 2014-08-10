using UnityEngine;

public class MoveWithCamera : MonoBehaviour
{
    private GameObject _cameraObject;

    void Start()
    {
        _cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        this.transform.position = new Vector3(_cameraObject.transform.position.x, _cameraObject.transform.position.y, 0);
    }
}

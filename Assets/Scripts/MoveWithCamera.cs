using UnityEngine;

public class MoveWithCamera : MonoBehaviour
{
    private GameObject _cameraObject;

    void Start()
    {
        
    }

    void Update()
    {
        _cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        if (_cameraObject != null)
        {
            this.transform.position = new Vector3(_cameraObject.transform.position.x, _cameraObject.transform.position.y, 0);
        }
        else
        {
            Debug.Log("Warning, camera not accessible.");
        }
    }
}

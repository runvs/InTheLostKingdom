using UnityEngine;

public class MoveWithCamera : MonoBehaviour
{
    public GameObject _cameraObject;

    void Start()
    {
        
    }

    void Update()
    {
        _cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        this.transform.position = new Vector3(_cameraObject.transform.position.x, _cameraObject.transform.position.y, 0);
        Debug.Log(_cameraObject.transform.position.x);
        if (_cameraObject != null)
        {
            
            Debug.Log(this.transform.position);
        }
        else
        {
            Debug.Log("Warning, camera not accessible.");
        }
    }
}

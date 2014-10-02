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
        gameObject.transform.position = new Vector3(_cameraObject.transform.position.x, _cameraObject.transform.position.y, 1);
        //Debug.Log(_cameraObject.transform.position.x);
        //Debug.Log(gameObject.transform.position.x);
    }
}

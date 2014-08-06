using UnityEngine;

public class PixelGridScript : MonoBehaviour
{
    private float cell_size = 1.0f / 16.0f;
    private float x, y, z;

    void Update()
    {
        x = Mathf.Round(transform.position.x / cell_size) * cell_size;
        y = Mathf.Round(transform.position.y / cell_size) * cell_size;
        z = transform.position.z;
    }
}

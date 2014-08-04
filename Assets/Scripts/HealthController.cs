using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float Health;

    // Use this for initialization
    void Start()
    {
        switch (this.tag)
        {
            case "Player":
                Health = GameProperties.PlayerMaxHealth;
                break;
            case "Enemies":
                Health = 4f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }
}

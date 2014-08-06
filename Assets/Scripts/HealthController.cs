using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float Health;

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

    void Update()
    {
        if (Health <= 0.0f && this.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}

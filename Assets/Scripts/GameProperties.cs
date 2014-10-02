
public static class GameProperties
{
    public static float PlayerMoveForce { get { return 300f; } }
    public static float PlayerMaxVelocity { get { return 0.7f; } }
    public static float PlayerMaxHealth { get { return 4f; } }
    public static float PlayerBaseDamage { get { return 2f; } }
    public static float PlayerHitKnockbackForce { get { return 7000f; } }

    public static float BaseInputTimer { get { return 0.2f; } }

    public static float EnemyKnockbackForce { get { return 400f; } }
    public static float EnemyBaseDamage { get { return 0.75f; } }
    public static float EnemyMoveForce { get { return 150f; } }

    public static float EnemyMaxHealth { get { return 5f; } }

    public static float JumpTime { get { return 0.20f; } }
}

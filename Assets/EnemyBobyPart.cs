using UnityEngine;

public class EnemyBobyPart : MonoBehaviour, IHittable
{
    public BodyPart bodyPart;

    public BodyPart GetBodyPart()
    {
        return bodyPart;
    }
    Enemy enemy;
    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }
    public void TakeDamage(float damage)
    {
        enemy.TakeDamage(damage);
    }
}

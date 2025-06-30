using UnityEngine;

public class EnemyBobyPart : MonoBehaviour, IHittable
{
    public BodyPart bodyPart; //적부위

    public BodyPart GetBodyPart()//적부위 정보 반환
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

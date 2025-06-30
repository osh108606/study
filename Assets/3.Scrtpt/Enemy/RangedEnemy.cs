using UnityEngine;
using UnityEngine.UIElements;

public class RangedEnemy : Enemy
{
    public Transform attackPointTr;//공격 시작포인트
    public EnemyBullet bulletPrefab;//사용할 총알
    public float time = 1f;

    public override void Attack()
    {
        Vector2 directtion = Player.Instance.Bodytr.transform.position - attackPointTr.transform.position;
        EnemyBullet bullet = Instantiate(bulletPrefab);
        bullet.gameObject.transform.position = attackPointTr.transform.position;
        bullet.Shoot(directtion.normalized);
    }
}

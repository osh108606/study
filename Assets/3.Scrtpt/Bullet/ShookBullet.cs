using UnityEngine;

public class ShookBullet : Bullet
{
    //소모성 아이템 탄약
    //충격탄
    //충격상태이상 효과 부착
    //충격상태이상 효과 : 일부 대상에게 일정시간동안 충격 상태이상
    

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("충격!");
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}

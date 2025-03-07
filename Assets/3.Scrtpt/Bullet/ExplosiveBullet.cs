using UnityEngine;

public class ExplosiveBullet : Bullet
{
    //소모성 아이템 탄약
    //폭발탄
    //체력 125% 방어도 125% 데미지
    


    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("폭발!");
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}

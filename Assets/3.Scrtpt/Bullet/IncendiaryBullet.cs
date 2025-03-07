using UnityEngine;

public class IncendiaryBullet : Bullet
{
    //소모성 아이템 탄약
    //소이탄
    //불상태이상 효과 부착
    //불상태이상 효과 : 일부 대상에게 일정시간동안 불데미지(무장갑,생체)
    //불데미지는 체력에 100% 방어도에 75% 데미지
    //사격제한
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("화염!");
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}

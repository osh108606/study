using UnityEngine;

public class ExplosiveBullet : Bullet
{
    //�Ҹ� ������ ź��
    //����ź
    //ü�� 125% �� 125% ������
    


    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("����!");
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}

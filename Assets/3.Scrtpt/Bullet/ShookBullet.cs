using UnityEngine;

public class ShookBullet : Bullet
{
    //�Ҹ� ������ ź��
    //���ź
    //��ݻ����̻� ȿ�� ����
    //��ݻ����̻� ȿ�� : �Ϻ� ��󿡰� �����ð����� ��� �����̻�
    

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("���!");
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class IncendiaryBullet : Bullet
{
    //�Ҹ� ������ ź��
    //����ź
    //�һ����̻� ȿ�� ����
    //�һ����̻� ȿ�� : �Ϻ� ��󿡰� �����ð����� �ҵ�����(���尩,��ü)
    //�ҵ������� ü�¿� 100% ���� 75% ������
    //�������
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("ȭ��!");
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}

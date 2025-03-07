using JetBrains.Annotations;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
//���� �Ѿ� �ڵ�
public class EnemyBullet : MonoBehaviour
{

    public float movespeed;
    public EnemyInfo enemyInfo;
    float t = 0;
    Vector2 direction;


    public void Shoot(Vector2 dir)
    {
        direction = dir;
    }

    // Update is called once per frame
    void Update()
    {
        //�Ѿ� �����ð�
        t += Time.deltaTime;
        if (t > 1f)
        {
            Destroy(gameObject);
        }
        //����
        transform.position = (Vector2)transform.position + direction * movespeed * Time.deltaTime;
    }


    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            player.TakeDamage(enemyInfo.attackDamage);
            Destroy(gameObject);
        }
    }
}

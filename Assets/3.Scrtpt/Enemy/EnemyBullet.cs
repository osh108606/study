using JetBrains.Annotations;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
//적의 총알 코드
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
        //총알 삭제시간
        t += Time.deltaTime;
        if (t > 1f)
        {
            Destroy(gameObject);
        }
        //방향
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

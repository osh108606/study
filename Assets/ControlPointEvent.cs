using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ControlPointEvent : MonoBehaviour
{
    public Collider2D collider2D;
    public Transform[] SpPoint;
    public Enemy[] enemiePrefab;
    List<Enemy> enemies = new List<Enemy> ();
    public void Start()
    {
        if (true)
        {
            ControlPointOn();
            Debug.Log("ControlPointOn()");
        }
    }
    public void Update()
    { 
    }
    //구현과는 다르게 원한것: 적 조합 프리펩? 같은것 만든뒤 
    //조합 단위로 랜덤한 스폰 포인트에 스폰하는것
    //조합이 격파 되면 새조합등장 
    public void ControlPointOn()
    {
        for(int i = 0; i<SpPoint.Length;i++)
        {
            Enemy meleeEnemy = GetEnemyInPool(EnemyType.Melee);
            meleeEnemy.transform.position = SpPoint[i].transform.position;
            Enemy rangeEnemy = GetEnemyInPool(EnemyType.Ranged);
            rangeEnemy.transform.position = SpPoint[i].transform.position;
        }
       

    }
    public Enemy GetEnemyInPool(EnemyType type)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            
            if (enemies[i].gameObject.activeSelf)
            {
                continue;
            }
            
            enemies[i].gameObject.SetActive(true);
            return enemies[i];
        }
        
        for(int i = 0; i< enemiePrefab.Length;i++)
        {
            if (enemiePrefab[i].enemyInfo.enemyType == type)
            {
                Enemy enemy = Instantiate(enemiePrefab[i]);
                enemies.Add(enemy);
                return enemy;
            }
        }
        return null;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
        }
    }
}

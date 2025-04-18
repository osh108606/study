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
    public void start()
    {
        if (false)
        {
            ControlPointOn();
        }
    }
    //�������� �ٸ��� ���Ѱ�: �� ���� ������? ������ ����� 
    //���� ������ ������ ���� ����Ʈ�� �����ϴ°�
    //������ ���� �Ǹ� �����յ��� 
    public void ControlPointOn()
    {
       Enemy enemy = GetEnemyInPool();
    }
    public Enemy GetEnemyInPool()
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

        for (int i = 0; i < enemiePrefab.Length; i++)
        {
            for (int j = 0; i < SpPoint.Length; j++)
            {
                Enemy enemy = enemiePrefab[i];
                Instantiate(enemy, SpPoint[j]);
                enemies.Add(enemy);
                return enemy;
            }

        }
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
        }
    }
}

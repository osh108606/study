using UnityEngine;

public class Item : MonoBehaviour
{
    public string key; // 아이템 식별 고유키
    //충돌처리
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log(" ");
            
            Destroy(gameObject);
        }
    }

}

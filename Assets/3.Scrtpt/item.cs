using UnityEngine;

public class item : MonoBehaviour
{
    public string key;
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log(" ");
            
            Destroy(gameObject);
        }
    }

}

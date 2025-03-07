using Unity.VisualScripting;
using UnityEngine;


public class bulletItem : item
{
    
    public Bullet bullet;
    public int count;
    public WeaponType weaponType;
    
    public void Update()
    {
        //if(weaponType)
        if(bullet.ammoitemType == AmmoitemType.ConsumableAmmo)
        {
            //drop한 총알의 weapontype(총알 종류)은 플레이어가 적을 죽인
            //무기의 weapontype에 따라 결정됨
            //weapontype은 플레이어가 들고있는 스페셜이 아닌 무기;
        }
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
  
            Debug.Log("획득");

            User.Instance.AddItem(key, count);
            
            Destroy(gameObject);
        }
    }
}

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
            //drop�� �Ѿ��� weapontype(�Ѿ� ����)�� �÷��̾ ���� ����
            //������ weapontype�� ���� ������
            //weapontype�� �÷��̾ ����ִ� ������� �ƴ� ����;
        }
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
  
            Debug.Log("ȹ��");

            User.Instance.AddItem(key, count);
            
            Destroy(gameObject);
        }
    }
}

using JetBrains.Annotations;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
//총알 타입(시스템기능)
public enum AmmoitemType
{
    ConsumableAmmo,//소모성 특수탄약
    WeaponAmmo//무기탄약
}

public class Bullet : MonoBehaviour
{
    public float movespeed; //총알속도
    public AmmoitemType ammoitemType; //총알 시스템타입
    public Weapon currentWeapon; //현재들고있는 장착한무기
    
    float t = 0; //총알 수명

    Vector2 direction; // 방향
    //총알 비활성화
        
    public void Shoot (Weapon weapon, Vector2 dir)
    {
        currentWeapon = weapon;
        direction = dir;
        t = 0;
    }

    
    void Update()
    {
        t += Time.deltaTime;
        if (t > 2f)
        {
            gameObject.SetActive(false);
        } 
        
        //위치이동
        transform.position = (Vector2)transform.position + direction* movespeed *Time.deltaTime;
    }

   
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            return;

        if(collision.gameObject.layer == LayerMask.NameToLayer("Hittalble"))
        {
            IHittable hittable = collision.GetComponent<IHittable>();
            hittable.TakeDamage(currentWeapon.weaponInfo.baseDamage);
            currentWeapon.Hittied(hittable.GetBodyPart());
            gameObject.SetActive(false);
        }
    }
}

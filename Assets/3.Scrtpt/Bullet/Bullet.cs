using JetBrains.Annotations;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
//총알 타입(시스템기능)
public enum AmmoitemType
{
    ConsumableAmmo,
    WeaponAmmo
}

public class Bullet : MonoBehaviour
{
    public float movespeed;

    public AmmoitemType ammoitemType;

    public Weapon currentWeapon;

    
    Vector2 direction;
    
    public void Shoot (Weapon weapon, Vector2 dir)
    {
        currentWeapon = weapon;
        direction = dir;
    }

   
    void Update()
    {
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
            Destroy(this.gameObject);
        }
    }
}

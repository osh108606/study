using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponInfo weaponInfo;
    public Bullet bulletPrefab;
    public float time = 1f;
    public WeaponPartType weaponPartType;
    public WeaponPart[] weaponParts;

    public int crurrentAmmo;

    public float GetDamage()
    {
        float weaponPartDamage = 0;
        for (int i =0; i < weaponParts.Length;i++)
        {
            if (weaponParts[i] == null)
                continue;
            weaponPartDamage += weaponParts[i].damage;        
        }
        return weaponInfo.baseDamage + weaponPartDamage;
    }

    public float GetAccuracy()
    {
        float weaponPartAccuracy = 0;
        for (int i = 0; i < weaponParts.Length; i++)
        {
            if (weaponParts[i] == null)
                continue;
            weaponPartAccuracy -= weaponParts[i].accuracy;
            
        }
        return weaponInfo.accuracy - weaponPartAccuracy;
    }

    
    //HG
    //보통 반동 보통 명중율
    //초탄(최소1최대5발) 변동 없음
    //SMG
    //낮은 반동 낮은 명중율
    //초탄(최소1최대5발)에 명중율 변동
    //AR
    //높은 명중율 보통 반동
    //초탄(최소1최대5발)에 반동 변동
    //MG
    //낮은 시작 명중율 시작 반동 발사시 높아지는 명중율과 반동

    public virtual void Start()
    {
        crurrentAmmo = weaponInfo.cilpammo;
    }
    public virtual void Update()
    {
        float FPS = weaponInfo.RPM / 60;
        float fireRate = 1f / FPS;
        time += Time.deltaTime;

        
        if (Input.GetMouseButtonDown(0) && weaponInfo.automaticFire == false &&time >= fireRate && weaponInfo.weaponType != WeaponType.SG && crurrentAmmo > 0)
        {
            Shoot();
            time = 0;
            crurrentAmmo--;
        }

        if (Input.GetMouseButton(0) && time >= fireRate && weaponInfo.weaponType != WeaponType.SG && weaponInfo.automaticFire == true && crurrentAmmo > 0)
        {
            Shoot();
            time = 0;
            crurrentAmmo--;
        }

        if (Input.GetMouseButtonDown(0)&& weaponInfo.weaponType == WeaponType.SG&& weaponInfo.automaticFire == false && time >= fireRate && crurrentAmmo > 0)
        {
            SGShoot();
            time = 0;
            crurrentAmmo--;
        }

        if (Input.GetMouseButton(0) && time >= fireRate && weaponInfo.weaponType == WeaponType.SG && weaponInfo.automaticFire == true && crurrentAmmo > 0)
        {
            SGShoot();
            time = 0;
            crurrentAmmo--;
        }

        if (Input.GetKeyDown(KeyCode.R) && (crurrentAmmo < weaponInfo.cilpammo))
        {
            Reload();
        }
    }
    //일반 발사
    public virtual void Shoot()
    {    
        Vector2 screenPoint = Input.mousePosition;
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint); ;
        Vector2 directtion = worldPoint - (Vector2)transform.position;


        Bullet bullet = Instantiate(bulletPrefab);
        bullet.gameObject.transform.position = transform.position;
        bullet.Shoot(this, directtion.normalized);
        
    }
    //산탄 발사
    public void SGShoot()
    {
        Vector2 screenPoint = Input.mousePosition;
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);

        //날아가야될 방향 = 목적지 - 출발지 
        Vector2 direction = (worldPoint - (Vector2)transform.position).normalized;


        for (int i = 0; i < 8; i++)
        {
            Quaternion rotation1 = Quaternion.Euler(0, 0, Random.Range(5f, -5f));
            Vector3 dir1 = rotation1 * direction;
            SGShoot(dir1);
        }
    }

    //산탄 구현
    void SGShoot(Vector2 dir)
    {
        Bullet bullet2 = Instantiate(bulletPrefab);
        bullet2.gameObject.transform.position = transform.position;
        bullet2.Shoot(this,dir);

    }

    //장전
    public void Reload()
    {
        Debug.Log("장전중");
        crurrentAmmo = weaponInfo.cilpammo;
        Debug.Log("장전완료");
        
    }

    public virtual void Hittied(BodyPart bodyPart)
    {

    }
}

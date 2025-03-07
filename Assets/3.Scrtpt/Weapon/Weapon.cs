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
    //���� �ݵ� ���� ������
    //��ź(�ּ�1�ִ�5��) ���� ����
    //SMG
    //���� �ݵ� ���� ������
    //��ź(�ּ�1�ִ�5��)�� ������ ����
    //AR
    //���� ������ ���� �ݵ�
    //��ź(�ּ�1�ִ�5��)�� �ݵ� ����
    //MG
    //���� ���� ������ ���� �ݵ� �߻�� �������� �������� �ݵ�

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
    //�Ϲ� �߻�
    public virtual void Shoot()
    {    
        Vector2 screenPoint = Input.mousePosition;
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint); ;
        Vector2 directtion = worldPoint - (Vector2)transform.position;


        Bullet bullet = Instantiate(bulletPrefab);
        bullet.gameObject.transform.position = transform.position;
        bullet.Shoot(this, directtion.normalized);
        
    }
    //��ź �߻�
    public void SGShoot()
    {
        Vector2 screenPoint = Input.mousePosition;
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);

        //���ư��ߵ� ���� = ������ - ����� 
        Vector2 direction = (worldPoint - (Vector2)transform.position).normalized;


        for (int i = 0; i < 8; i++)
        {
            Quaternion rotation1 = Quaternion.Euler(0, 0, Random.Range(5f, -5f));
            Vector3 dir1 = rotation1 * direction;
            SGShoot(dir1);
        }
    }

    //��ź ����
    void SGShoot(Vector2 dir)
    {
        Bullet bullet2 = Instantiate(bulletPrefab);
        bullet2.gameObject.transform.position = transform.position;
        bullet2.Shoot(this,dir);

    }

    //����
    public void Reload()
    {
        Debug.Log("������");
        crurrentAmmo = weaponInfo.cilpammo;
        Debug.Log("�����Ϸ�");
        
    }

    public virtual void Hittied(BodyPart bodyPart)
    {

    }
}

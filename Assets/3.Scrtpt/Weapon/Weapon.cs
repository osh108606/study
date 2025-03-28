using System.Collections.Generic;
using UnityEngine;

// Weapon Ŭ������ MonoBehaviour�� ��ӹ޾� Unity�� ���� ������Ʈ�� �����մϴ�.
public class Weapon : MonoBehaviour
{
    // ���� �⺻ ������ ���� ����
    public WeaponInfo weaponInfo;
    // �߻��� �Ѿ� ������ (�̸� ������� �Ѿ� ���ø�)
    public Bullet bulletPrefab;
    // �߻� ���� ������ �ð� ����
    public float time = 1f;
    // ���� ��ǰ�� ���� Ÿ��
    //public WeaponPartType weaponPartType;
    // ���⿡ ������ ��ǰ �迭
    public WeaponPart[] weaponParts;

    // ���� ���� ź�� ��
    public int crurrentAmmo;

    // �Ѿ� ������Ʈ Ǯ���� ����� ����Ʈ (Ȱ��ȭ�� �Ѿ˵��� ������ �ǵ��� ����)
    List<Bullet> crurrentBullets = new List<Bullet>();
    // ������Ʈ Ǯ���� �Ѿ� ����Ʈ (��Ȱ��ȭ�� �Ѿ� ����)
    List<Bullet> bullets = new List<Bullet>();

    // ������ ���� �������� ����ϴ� �Լ�
    public float GetDamage()
    {
        float weaponPartDamage = 0;
        // ���⿡ ������ �� ��ǰ���� �߰� �������� ����
        for (int i = 0; i < weaponParts.Length; i++)
        {
            if (weaponParts[i] == null)
                continue;
            weaponPartDamage += weaponParts[i].damage;
        }
        // �⺻ �������� ��ǰ �߰� �������� �ջ��Ͽ� ��ȯ
        return weaponInfo.baseDamage + weaponPartDamage;
    }

    // ������ ���� ���߷�(��Ȯ��)�� ����ϴ� �Լ�
    public float GetAccuracy()
    {
        float weaponPartAccuracy = 0;
        // �� ��ǰ���� �����ϴ� ���߷� ����ġ�� ���� (���� ���� ���� ����)
        for (int i = 0; i < weaponParts.Length; i++)
        {
            if (weaponParts[i] == null)
                continue;
            weaponPartAccuracy -= weaponParts[i].accuracy;
        }
        // �⺻ ���߷����� ��ǰ ����ġ�� �����Ͽ� ���� ���߷� ���
        return weaponInfo.accuracy - weaponPartAccuracy;
    }

    /* 
       ���� Ÿ�Ժ� Ư���� ���� �ּ�
       HG  : ���� �ݵ�, ���� ���߷�, ��ź(�ּ� 1 ~ �ִ� 5��) ���� ����
       SMG : ���� �ݵ�, ���� ���߷�, ��ź(�ּ� 1 ~ �ִ� 5��)�� ���߷� ����
       AR  : ���� ���߷�, ���� �ݵ�, ��ź(�ּ� 1 ~ �ִ� 5��)�� �ݵ� ����
       MG  : ���� ���� ���߷�, ���� �ݵ�, �߻� �� ���߷��� �ݵ��� ����
    */

    // �ʱ�ȭ �޼���: ���Ⱑ ���۵� �� ȣ���
    public virtual void Start()
    {
        // �ʱ� ź�� ���� ������ �ִ� ź�� ���� ����
        crurrentAmmo = weaponInfo.cilpammo;
    }

    // �� �����Ӹ��� ȣ��Ǵ� ������Ʈ �޼���
    public virtual void Update()
    {
        // �д� �߻� �ӵ�(RPM)�� �ʴ� �߻� �ӵ��� ��ȯ
        float FPS = weaponInfo.RPM / 60;
        // �߻� ���� (1�ʸ� FPS�� ���� ��)
        float fireRate = 1f / FPS;
        // ��� �ð� ����
        time += Time.deltaTime;

        // ���ڵ� ���� & ��ź���� �ƴ� ���: ���콺 ���� ��ư Ŭ�� �� �߻�
        if (Input.GetMouseButtonDown(0) && weaponInfo.automaticFire == false && time >= fireRate && weaponInfo.weaponType != WeaponType.SG && crurrentAmmo > 0)
        {
            Shoot();           // �Ϲ� �߻� �Լ� ȣ��
            time = 0;          // �߻� �� �ð� �ʱ�ȭ
            crurrentAmmo--;    // ź�� ����
        }

        // �ڵ� ���� & ��ź���� �ƴ� ���: ���콺 ���� ��ư ������ ���� �� �߻�
        if (Input.GetMouseButton(0) && time >= fireRate && weaponInfo.weaponType != WeaponType.SG && weaponInfo.automaticFire == true && crurrentAmmo > 0)
        {
            Shoot();
            time = 0;
            crurrentAmmo--;
        }

        // ���ڵ� ��ź���� ���: ���콺 ���� ��ư Ŭ�� �� ��ź �߻�
        if (Input.GetMouseButtonDown(0) && weaponInfo.weaponType == WeaponType.SG && weaponInfo.automaticFire == false && time >= fireRate && crurrentAmmo > 0)
        {
            SGShoot();
            time = 0;
            crurrentAmmo--;
        }

        // �ڵ� ��ź���� ���: ���콺 ���� ��ư ������ ���� �� ��ź �߻�
        if (Input.GetMouseButton(0) && time >= fireRate && weaponInfo.weaponType == WeaponType.SG && weaponInfo.automaticFire == true && crurrentAmmo > 0)
        {
            SGShoot();
            time = 0;
            crurrentAmmo--;
        }

        // ������: RŰ�� ������ �� ���� ź���� �ִ� ź�ຸ�� ������ ������ ����
        if (Input.GetKeyDown(KeyCode.R) && (crurrentAmmo < weaponInfo.cilpammo))
        {
            Reload();
        }
    }

    // �Ϲ� �߻� �޼���: �Ѿ��� �ϳ� �߻��մϴ�.
    public virtual void Shoot()
    {
        // ���콺�� ��ũ�� ��ǥ�� ������
        Vector2 screenPoint = Input.mousePosition;
        // ��ũ�� ��ǥ�� ���� ��ǥ�� ��ȯ (���� ��ġ�� ���ϱ� ����)
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
        // �Ѿ��� ���ư� ���� ��� (���� ��ǥ ����)
        Vector2 directtion = worldPoint - (Vector2)transform.position;

        // ������Ʈ Ǯ���� ����Ͽ� �Ѿ��� ������ (Ȱ��ȭ�� �Ѿ��� ������ ���� ����)
        Bullet bullet = GetbulletInPool();
        // �Ѿ��� ��ġ�� ������ ��ġ�� ����
        bullet.gameObject.transform.position = transform.position;
        // �Ѿ��� ������ �������� �߻� (����ȭ�� ���� ���� ���)
        bullet.Shoot(this, directtion.normalized);
    }

    // ��ź�� �߻� �޼���: �� ���� ���� ���� �Ѿ��� �߻��մϴ�.
    public void SGShoot()
    {
        // ���콺�� ��ũ�� ��ǥ�� ������
        Vector2 screenPoint = Input.mousePosition;
        // ��ũ�� ��ǥ�� ���� ��ǥ�� ��ȯ
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);

        // �⺻ �߻� ���� ��� (����ȭ�� ���� ����)
        Vector2 direction = (worldPoint - (Vector2)transform.position).normalized;

        // 8���� ��ź�� �߻��ϸ鼭 �� �Ѿ˿� �ణ�� ���� ����(��5��) ����
        for (int i = 0; i < 8; i++)
        {
            // -5������ 5�� ������ ���� ȸ���� ����
            Quaternion rotation1 = Quaternion.Euler(0, 0, Random.Range(5f, -5f));
            // ���� ȸ������ ������ ���ο� �߻� ���� ���
            Vector3 dir1 = rotation1 * direction;
            // ���� ��ź �߻� �޼��� ȣ��
            SGShoot(dir1);
        }
    }

    // ��ź�� ���� �Ѿ� �߻� �޼���: �־��� �������� �Ѿ��� �߻��մϴ�.
    void SGShoot(Vector2 dir)
    {
        // �Ѿ� �������� �ν��Ͻ�ȭ�Ͽ� ���ο� �Ѿ� ����
        Bullet bullet2 = GetbulletInPoolShoot();
        // ������ �Ѿ��� ��ġ�� ������ ��ġ�� ����
        bullet2.gameObject.transform.position = transform.position;
        // �Ѿ��� �־��� �������� �߻�
        bullet2.Shoot(this, dir);
    }

    // �Ѿ� ������Ʈ Ǯ�� �޼���: ��Ȱ��ȭ�� �Ѿ��� ��ȯ�ϰų�, ������ ���� ����
    public Bullet GetbulletInPool()
    {
        // ����Ʈ�� �ִ� �Ѿ˵��� ��ȸ�ϸ�
        for (int i = 0; i < bullets.Count; i++)
        {
            // �̹� Ȱ��ȭ�� �Ѿ��� �ǳʶ�
            if (bullets[i].gameObject.activeSelf)
            {
                continue;
            }
            // ��Ȱ��ȭ�� �Ѿ��� Ȱ��ȭ��Ű�� ��ȯ
            bullets[i].gameObject.SetActive(true);
            return bullets[i];
        }
        // ��� ������ �Ѿ��� ���ٸ�, ���� �����Ͽ� ����Ʈ�� �߰� �� ��ȯ
        Bullet bullet = Instantiate(bulletPrefab);
        bullets.Add(bullet);
        return bullet;
    }

    public Bullet GetbulletInPoolShoot()
    {
        // ����Ʈ�� �ִ� �Ѿ˵��� ��ȸ�ϸ�
        for (int i = 0; i < bullets.Count; i++)
        {
            // �̹� Ȱ��ȭ�� �Ѿ��� �ǳʶ�
            if (bullets[i].gameObject.activeSelf)
            {
                continue;
            }
            // ��Ȱ��ȭ�� �Ѿ��� Ȱ��ȭ��Ű�� ��ȯ
            bullets[i].gameObject.SetActive(true);
            return bullets[i];
        }
        // ��� ������ �Ѿ��� ���ٸ�, ���� �����Ͽ� ����Ʈ�� �߰� �� ��ȯ
        Bullet bullet = Instantiate(bulletPrefab);
        bullets.Add(bullet);
        bullets.Add(bullet);
        bullets.Add(bullet);
        bullets.Add(bullet);
        bullets.Add(bullet);
        bullets.Add(bullet);
        bullets.Add(bullet);
        bullets.Add(bullet);
        return bullet;
    }

    // ������ �޼���: ź���� �ִ�ġ�� ȸ���մϴ�.
    public void Reload()
    {
        // ������ ������ �α׷� ���
        Debug.Log("������");
        // ���� ź�� ���� �ִ� ź�� ���� �缳��
        crurrentAmmo = weaponInfo.cilpammo;
        // ������ �ϷḦ �α׷� ���
        Debug.Log("�����Ϸ�");
    }

    // ���� �� ó���� �޼��� (���� Ŭ�������� �������̵��Ͽ� ���)
    public virtual void Hittied(BodyPart bodyPart)
    {
        // �⺻ ������ ����
    }
}

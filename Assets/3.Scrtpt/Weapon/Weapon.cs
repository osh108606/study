using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

// Weapon Ŭ������ MonoBehaviour�� ��ӹ޾� Unity�� ���� ������Ʈ�� �����մϴ�.
public class Weapon : MonoBehaviour
{

    // ���� �⺻ ������ ���� ����
    public WeaponInfo weaponInfo;
    // �߻��� �Ѿ� ������ (�̸� ������� �Ѿ� ���ø�)
    public Bullet bulletPrefab;
    //���� �ٸ����̼� �� ���� �ɷ�ġ
    public float accuracyMultiy=1;
    public float stabilityMultiy=1;
    public int exCilpammo=0;
    // �߻� ���� ������ �ð� ����
    public float time = 1f;
    
    // ���⿡ ������ ��ǰ �迭
    public WeaponPart[] weaponParts;

    private bool isReloading = false;
    private float reloadTimer = 0f;

    [SerializeField]
    WeaponSlotType slotType;

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
        return accuracyMultiy * weaponInfo.accuracy - weaponPartAccuracy;
    }

    // ������ ���� ������(�ݵ�)�� ����ϴ� �Լ�
    public float GetStability()
    {
        float weaponPartStability = 0;
        // �� ��ǰ���� �����ϴ� ������ ����ġ�� ���� (���� ���� ���� ����)
        for (int i = 0; i < weaponParts.Length; i++)
        {
            if (weaponParts[i] == null)
                continue;
            weaponPartStability -= weaponParts[i].stability;
        }
        // �⺻ ���������� ��ǰ ����ġ�� �����Ͽ� ���� ������ ���
        return stabilityMultiy * weaponInfo.stability - weaponPartStability;
    }

    // ������ ���� ������(�ݵ�)�� ����ϴ� �Լ�
    public float Getcilpammo()
    {
        float weaponPartCilpammo = 0;
        // �� ��ǰ���� �����ϴ� ������ ����ġ�� ���� (���� ���� ���� ����)
        for (int i = 0; i < weaponParts.Length; i++)
        {
            if (weaponParts[i] == null)
                continue;
            weaponPartCilpammo -= weaponParts[i].cilpammo;
        }
        // �⺻ ���������� ��ǰ ����ġ�� �����Ͽ� ���� ������ ���
        return (exCilpammo + weaponInfo.cilpammo) - weaponPartCilpammo;
    }
    /* 
       ���� Ÿ�Ժ� Ư���� ���� �ּ�
       HG  : ���� �ݵ�, ���� ���߷�, ��ź(�ּ� 1 ~ �ִ� 5��) ���� ����
       SMG : ���� �ݵ�, ���� ���߷�, ��ź(�ּ� 1 ~ �ִ� 5��)�� ���߷� ����
       AR  : ���� ���߷�, ���� �ݵ�, ��ź(�ּ� 1 ~ �ִ� 5��)�� �ݵ� ����
       MG  : ���� ���� ���߷�, ���� �ݵ�, �߻� �� ���߷��� �ݵ��� ����
    */

    // �ʱ�ȭ, ���Ⱑ ���۵� �� ȣ��
    public virtual void Start()
    {
        
    }

    // �� �����Ӹ��� ������Ʈ
    public virtual void Update()
    {
        // �д� �߻� �ӵ�(RPM)�� �ʴ� �߻� �ӵ��� ��ȯ
        float FPS = weaponInfo.RPM / 60;
        // �߻� ���� (1�ʸ� FPS�� ���� ��)
        float fireRate = 1f / FPS;
        // ��� �ð� ����
        time += Time.deltaTime;

        int currentSlotIndex = (int)User.Instance.userData.currentSlot;
        int[] ammoArray = User.Instance.userData.currentAmmoSlot;
        
        // �߻� ���� ����
        bool canFire = time >= fireRate && ammoArray[currentSlotIndex] > 0;

        // �ڵ� ���ڵ� ����
        bool isFirePressed = weaponInfo.automaticFire ? Input.GetMouseButton(0) : Input.GetMouseButtonDown(0);



        if (isReloading)
        {
            reloadTimer -= Time.deltaTime;

            if (reloadTimer <= 0f)
            {
                
                int current = ammoArray[currentSlotIndex];
                
                int max = weaponInfo.cilpammo;

                int reload = max - current;

                //üũx
                Ammo ammo = User.Instance.GetUesrAmmo(weaponInfo.ammoType);

                // źâ ����
                ammoArray[currentSlotIndex] += reload;
                // �κ��丮 ź�� ����
                ammo.count -= reload;
                isReloading = false;
            }
            
            return; // ���� �߿� �߻�, ������, �Է� �� ��� ����
        }

        // ������: RŰ�� ������ �� ���� ź���� �ִ� ź�ຸ�� ������ ������ ����
        if (Input.GetKeyDown(KeyCode.R) && (ammoArray[currentSlotIndex] < weaponInfo.cilpammo))
        {
            Reload();
        }

        if (!canFire)
        {
            return;
        }
            
        if (isFirePressed)
        {
            if (weaponInfo.weaponType == WeaponType.SG)
            {
                SGShoot();
            }
            else
            {
                Shoot();
            }

            time = 0f;
            ammoArray[currentSlotIndex]--;
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
        
        Debug.Log("������");
        // ���� ź�� ���� �ִ� ź�� ���� �缳��
        if (isReloading) 
            return;

        isReloading = true;
        reloadTimer = weaponInfo.reloadSpeed;
        
        Debug.Log("�����Ϸ�");
    }

    public void ChangeSlot(WeaponSlotType weaponSlot)
    {
        slotType = weaponSlot;
    }

    // ���� �� ó���� �޼��� (���� Ŭ�������� �������̵��Ͽ� ���)
    public virtual void Hittied(BodyPart bodyPart)
    {
        // �⺻ ������ ����
    }
}

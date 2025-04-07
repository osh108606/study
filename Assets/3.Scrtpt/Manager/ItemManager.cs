using JetBrains.Annotations;    // JetBrains�� �ֳ����̼��� ��� (Ư�� �ڵ� �м� �� ������ ���� ����)
using Unity.VisualScripting;     // ����Ƽ ���־� ��ũ���� ���� ��� (���־� ��ũ���� ���տ�, ���� �ڵ忡���� ���� �������� ����)
using UnityEngine;

// ���� �� ������ �����͸� �����ϴ� ������ �Ŵ��� Ŭ����

// �������� ������ ��Ÿ���� ������
public enum ItemType
{
    equipment,  // ��� ������
    Consume,    // �Ҹ� ������
    blueprint,  // ���赵 ������
    Ingredient  // ��� ������
}

// �������� ����� ��Ÿ���� ������ (���� �Ǵ� ǰ���� ���� ����)
public enum Grade
{
    Low,        // ���� ��� (ȸ��)
    Common,     // �Ϲ� ��� (�ʷ�)
    Uncommon,   // �ణ ���� ��� (�Ķ�)
    Rare,       // ��� (����)
    HighEnd,    // ��� (���)
    Named,      // �̸��� �ִ� Ư���� ��� (���� ���)
    Exotic,     // �̱����� ��� (����)
    Set         // ��Ʈ ȿ���� �ִ� ��� (���� �ʷ�)
}

// ������ �Ŵ��� Ŭ����: ������ ��� ������ �����͸� �����ϸ�, �̱��� ������ ����Ͽ� ���� ������ �����ϰ� ��
public class ItemManager : MonoBehaviour
{
    // �̱��� �ν��Ͻ� (�������� ���� ����)
    public static ItemManager Instance;

    // �⺻ ���� ���� (��: ���� �� �⺻ ���� �����͸� ����)
    public WeaponInfo weaponinfo;

    // ���� ������ ������ �迭 (Inspector���� �Ҵ�; ���� ���� ������ �����͵��� ����)
    public WeaponItemData[] weaponItemDatas; // ���� ������
    // ��� ������ ������ �迭 (ĳ������ ���� ��� ��)
    public GearItemData[] gearItemDatas;     // ��� ������
    // �Ҹ�ǰ ������ ������ �迭 (ȸ����, ���� ������ ��)
    public ItemData[] consumDatas;           // �Ҹ�ǰ ������
    // ����(���赵) ������ ������ �迭 (������ ���ۿ� �ʿ��� ���赵)
    public ItemData[] blueprintDatas;        // ���赵 ������
    // ��� ������ ������ �迭 (���ۿ� �ʿ��� ����� ��)
    public ItemData[] IngredientDatas;       // ��� ������

    // Awake �޼���: ���� ���� ���� �̱��� �ν��Ͻ��� �ʱ�ȭ�մϴ�.
    private void Awake()
    {
        Instance = this;
    }

    // ���� ���� �迭 (���� ���� ������ Inspector���� �Ҵ�)
    public WeaponInfo[] weaponInfos;

    // Start �޼���: ���� ���� �� �ʱ� ���� ������ �����մϴ�.
    private void Start()
    {
        // ���÷� HG Ÿ��(����) ������ ������ ������ Weaponinfo�� ����
        weaponinfo = GetWeaponData(WeaponType.HG);
    }

    // key ������ ���� ������ �����͸� �˻��Ͽ� ��ȯ�ϴ� �޼���
    public WeaponItemData GetWeaponItemData(string key)
    {
        // �迭 �� ��� ���� ������ �����͸� ��ȸ
        for (int i = 0; i < weaponItemDatas.Length; i++)
        {
            // ���� �ش� �������� key�� ���ڷ� ���޵� key�� ��ġ�ϸ�
            if (weaponItemDatas[i].key == key)
            {
                // �ش� ���� ������ �����͸� ��ȯ
                return weaponItemDatas[i];
            }
        }
        // ��ġ�ϴ� �����Ͱ� ���� ��� null ��ȯ
        return null;
    }

    // key ������ ��� ������ �����͸� �˻��Ͽ� ��ȯ�ϴ� �޼���
    public GearItemData GetGearItemData(string key)
    {
        // �迭 �� ��� ��� ������ �����͸� ��ȸ
        for (int i = 0; i < gearItemDatas.Length; i++)
        {
            // key�� ��ġ�ϸ� �ش� �����͸� ��ȯ
            if (gearItemDatas[i].key == key)
            {
                return gearItemDatas[i];
            }
        }
        // ��ġ�ϴ� �����Ͱ� ������ null ��ȯ
        return null;
    }

    // ���� Ÿ��(WeaponType)�� ������� ���� ������ �˻��ϴ� �޼���
    public WeaponInfo GetWeaponData(WeaponType weaponType)
    {
        // weaponInfos �迭 �� ��� ���� ������ ��ȸ
        for (int i = 0; i < weaponInfos.Length; i++)
        {
            // ���� ���� Ÿ���� ���ڷ� ���޵� weaponType�� ��ġ�ϸ�
            if (weaponInfos[i].weaponType == weaponType)
            {
                // �ش� ���� ������ Weaponinfo�� �����ϰ� ��ȯ
                weaponinfo = weaponInfos[i];
                return weaponinfo;
            }
        }
        // ��ġ�ϴ� ���� ������ ������ null ��ȯ
        return null;
    }
}
// ��� ������ �������� �⺻ Ŭ����
[System.Serializable]
public class ItemData
{
    // �������� �ĺ��ϱ� ���� ���� Ű
    public string key;
    // �������� �̸�
    public string name;
    // ������ ����� �̹��� (UI�� ǥ���ϱ� ���� Sprite)
    public Sprite thum;
    // �������� ���� (���, �Ҹ�ǰ, ���赵, ��� ��)
    public ItemType itemType;
}
// ���� ������ �����͸� ��Ÿ���� Ŭ���� (������ ������ ���)
// [System.Serializable] ��Ʈ����Ʈ�� ����Ͽ� Inspector���� �����͸� Ȯ���ϰ� ������ �� �ֽ��ϴ�.
[System.Serializable]
public class WeaponItemData : ItemData
{
    // ���⿡ ���� �� ���� (WeaponInfo ScriptableObject�� ���� ���ǵ� ���� ������)
    public WeaponInfo weaponInfo;
    
    // ������ ���
    public Grade grade;
}

// ��� ������ �����͸� ��Ÿ���� Ŭ���� (������ ������ ���)
public class GearItemData : ItemData
{
    
    // ����� ���
    public Grade grade;
}



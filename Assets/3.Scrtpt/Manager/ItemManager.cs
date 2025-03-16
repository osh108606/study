using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

//������ �Ŵ��� �ڵ� ������ �����۵����͸� ����



//������ ����
public enum ItemType
{
    equipment,//���
    Consume,//�Ҹ�
    blueprint,//���赵
    Ingredient//���
}
//������ ���
public enum Grade
{
    Low,        // ȸ��
    Common,     // �ʷ�
    Uncommon,   // �Ķ�
    Rare,       // ����
    HighEnd,    // ���
    Named,      // ���� ���
    Exotic,     // ����
    Set         // ���� �ʷ�
}
public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    public WeaponInfo Weaponinfo;

    public WeaponItemData[] weaponItemDatas;//����
    public GearItemData[] gearItemDatas;//���
    public ItemData[] consumDatas;//�Ҹ�ǰ
    public ItemData[] blueprintDatas;//���ۼ�
    public ItemData[] IngredientDatas;//����
    private void Awake()
    {
        Instance = this;
    }
    public WeaponInfo[] weaponInfos;

    private void Start()
    {
        Weaponinfo = GetWeaponData(WeaponType.HG);

    }

    public WeaponItemData GetWeaponItemData(string key)
    {
        for (int i = 0; i < weaponItemDatas.Length; i++)
        {
            if (weaponItemDatas[i].key == key)
            {
                return weaponItemDatas[i];
            }
        }
        return null;
    }

    public GearItemData GetGearItemData(string key)
    {
        for (int i = 0; i < gearItemDatas.Length; i++)
        {
            if (gearItemDatas[i].key == key)
            {
                return gearItemDatas[i];
            }
        }
        return null;
    }



    public WeaponInfo GetWeaponData(WeaponType weaponType)
    {
        for (int i = 0; i < weaponInfos.Length; i++)
        {
            if (weaponInfos[i].weaponType == weaponType)
            {
                Weaponinfo = weaponInfos[i];
                return Weaponinfo;
            }

        }
        return null;
    }
}

[System.Serializable]
public class WeaponItemData : ItemData
{
    public WeaponInfo WeaponInfo;
    public Grade grade;
}

public class GearItemData : ItemData
{
    //public WeaponInfo WeaponInfo;
    public Grade grade;
}

[System.Serializable]
public class ItemData
{
    public string key;
    public string name;
    public Sprite thum;
    public ItemType itemType;
}


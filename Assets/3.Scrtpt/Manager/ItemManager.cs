using JetBrains.Annotations;
using UnityEngine;
//������ ����
public enum ItemType
{
    Gear,//���
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

    public GearItemData[] gearItemDatas;
    public ItemData[] consumDatas;
    public ItemData[] blueprintDatas;
    public ItemData[] IngredientDatas;
    private void Awake()
    {
        Instance = this;
    }
    public WeaponInfo[] weaponInfos;

    private void Start()
    {
        Weaponinfo = GetWeaponData(WeaponType.HG);

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
public class GearItemData:ItemData
{
    public WeaponInfo WeaponInfo;
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


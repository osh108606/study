using JetBrains.Annotations;
using UnityEngine;
//아이템 유형
public enum ItemType
{
    Gear,//장비
    Consume,//소모
    blueprint,//설계도
    Ingredient//재료
}
//아이템 등급
public enum Grade
{
    Low,        // 회색
    Common,     // 초록
    Uncommon,   // 파랑
    Rare,       // 보라
    HighEnd,    // 노랑
    Named,      // 진한 노랑
    Exotic,     // 빨강
    Set         // 진한 초록
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


using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

//아이템 매니저 코드 게임의 아이템데이터를 관리



//아이템 유형
public enum ItemType
{
    equipment,//장비
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

    public WeaponItemData[] weaponItemDatas;//무기
    public GearItemData[] gearItemDatas;//장비
    public ItemData[] consumDatas;//소모품
    public ItemData[] blueprintDatas;//제작서
    public ItemData[] IngredientDatas;//제료
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


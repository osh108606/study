using JetBrains.Annotations;    // JetBrains의 애너테이션을 사용 (특정 코드 분석 및 검증을 위한 도구)
using Unity.VisualScripting;     // 유니티 비주얼 스크립팅 관련 기능 (비주얼 스크립팅 통합용, 현재 코드에서는 직접 사용되지는 않음)
using UnityEngine;

// 게임 내 아이템 데이터를 관리하는 아이템 매니저 클래스

// 아이템의 종류를 나타내는 열거형
public enum ItemType
{
    equipment,  // 장비 아이템
    Consume,    // 소모성 아이템
    blueprint,  // 설계도 아이템
    Ingredient  // 재료 아이템
}

// 아이템의 등급을 나타내는 열거형 (색상 또는 품질에 따라 구분)
public enum Grade
{
    Low,        // 낮은 등급 (회색)
    Common,     // 일반 등급 (초록)
    Uncommon,   // 약간 높은 등급 (파랑)
    Rare,       // 희귀 (보라)
    HighEnd,    // 고급 (노랑)
    Named,      // 이름이 있는 특별한 등급 (진한 노랑)
    Exotic,     // 이국적인 등급 (빨강)
    Set         // 세트 효과가 있는 등급 (진한 초록)
}

// 아이템 매니저 클래스: 게임의 모든 아이템 데이터를 관리하며, 싱글톤 패턴을 사용하여 전역 접근을 용이하게 함
public class ItemManager : MonoBehaviour
{
    // 싱글톤 인스턴스 (전역에서 접근 가능)
    public static ItemManager Instance;

    // 기본 무기 정보 (예: 권총 등 기본 무기 데이터를 저장)
    public WeaponInfo weaponinfo;

    // 무기 아이템 데이터 배열 (Inspector에서 할당; 무기 관련 아이템 데이터들을 저장)
    public WeaponItemData[] weaponItemDatas; // 무기 데이터
    // 장비 아이템 데이터 배열 (캐릭터의 착용 장비 등)
    public GearItemData[] gearItemDatas;     // 장비 데이터
    // 소모품 아이템 데이터 배열 (회복제, 버프 아이템 등)
    public ItemData[] consumDatas;           // 소모품 데이터
    // 제작(설계도) 아이템 데이터 배열 (아이템 제작에 필요한 설계도)
    public ItemData[] blueprintDatas;        // 설계도 데이터
    // 재료 아이템 데이터 배열 (제작에 필요한 원재료 등)
    public ItemData[] IngredientDatas;       // 재료 데이터

    // Awake 메서드: 게임 시작 전에 싱글톤 인스턴스를 초기화합니다.
    private void Awake()
    {
        Instance = this;
    }

    // 무기 정보 배열 (여러 무기 정보를 Inspector에서 할당)
    public WeaponInfo[] weaponInfos;

    // Start 메서드: 게임 시작 시 초기 무기 정보를 설정합니다.
    private void Start()
    {
        // 예시로 HG 타입(권총) 무기의 정보를 가져와 Weaponinfo에 저장
        weaponinfo = GetWeaponData(WeaponType.HG);
    }

    // key 값으로 무기 아이템 데이터를 검색하여 반환하는 메서드
    public WeaponItemData GetWeaponItemData(string key)
    {
        // 배열 내 모든 무기 아이템 데이터를 순회
        for (int i = 0; i < weaponItemDatas.Length; i++)
        {
            // 만약 해당 아이템의 key가 인자로 전달된 key와 일치하면
            if (weaponItemDatas[i].key == key)
            {
                // 해당 무기 아이템 데이터를 반환
                return weaponItemDatas[i];
            }
        }
        // 일치하는 데이터가 없을 경우 null 반환
        return null;
    }

    // key 값으로 장비 아이템 데이터를 검색하여 반환하는 메서드
    public GearItemData GetGearItemData(string key)
    {
        // 배열 내 모든 장비 아이템 데이터를 순회
        for (int i = 0; i < gearItemDatas.Length; i++)
        {
            // key가 일치하면 해당 데이터를 반환
            if (gearItemDatas[i].key == key)
            {
                return gearItemDatas[i];
            }
        }
        // 일치하는 데이터가 없으면 null 반환
        return null;
    }

    // 무기 타입(WeaponType)을 기반으로 무기 정보를 검색하는 메서드
    public WeaponInfo GetWeaponData(WeaponType weaponType)
    {
        // weaponInfos 배열 내 모든 무기 정보를 순회
        for (int i = 0; i < weaponInfos.Length; i++)
        {
            // 만약 무기 타입이 인자로 전달된 weaponType과 일치하면
            if (weaponInfos[i].weaponType == weaponType)
            {
                // 해당 무기 정보를 Weaponinfo에 저장하고 반환
                weaponinfo = weaponInfos[i];
                return weaponinfo;
            }
        }
        // 일치하는 무기 정보가 없으면 null 반환
        return null;
    }
}
// 모든 아이템 데이터의 기본 클래스
[System.Serializable]
public class ItemData
{
    // 아이템을 식별하기 위한 고유 키
    public string key;
    // 아이템의 이름
    public string name;
    // 아이템 썸네일 이미지 (UI에 표시하기 위한 Sprite)
    public Sprite thum;
    // 아이템의 종류 (장비, 소모품, 설계도, 재료 등)
    public ItemType itemType;
}
// 무기 아이템 데이터를 나타내는 클래스 (아이템 데이터 상속)
// [System.Serializable] 어트리뷰트를 사용하여 Inspector에서 데이터를 확인하고 수정할 수 있습니다.
[System.Serializable]
public class WeaponItemData : ItemData
{
    // 무기에 대한 상세 정보 (WeaponInfo ScriptableObject를 통해 정의된 무기 데이터)
    public WeaponInfo weaponInfo;
    
    // 무기의 등급
    public Grade grade;
}

// 장비 아이템 데이터를 나타내는 클래스 (아이템 데이터 상속)
public class GearItemData : ItemData
{
    
    // 장비의 등급
    public Grade grade;
}



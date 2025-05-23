using System.Collections.Generic;
using UnityEngine;

// 유저 데이터를 관리하는 클래스
// 싱글톤 패턴을 사용
public class User : MonoBehaviour
{
    // 싱글톤 인스턴스
    public static User Instance;

    // 현재 유저의 데이터 (닉네임, 보유 아이템, 무기 등 포함)
    public UserData userData;

    // 현재 선택된 장비 데이터를 저장하는 변수
    public Equipment equipment;

    // bulletItem 객체 (총알 아이템 관련, bulletItem 클래스는 별도로 정의되어 있어야 함)
    public bulletItem bulletItem;

    // 디버그 또는 테스트용으로 입력받는 아이템 이름
    public string itemName;
    // 디버그 또는 테스트용으로 입력받는 아이템 개수
    public int itemCount;

    // Awake()는 스크립트 인스턴스가 생성될 때 호출되며, 싱글톤 인스턴스를 초기화합니다.
    private void Awake()
    {
        Instance = this;

        // "UserData"라는 파일 이름으로 저장된 데이터를 불러옵니다.
        userData = SaveManager.LoadData<UserData>("UserData");

        // 저장된 유저 데이터가 없으면 초기 유저 데이터를 생성합니다.
        if (userData == null)
        {
            userData = new UserData();
            userData.nickname = "player";


            Equipment main1 = new Equipment();

            main1.key = WeaponType.AR.ToString();
            main1.setUpType = WeaponSlotType.Main1;
            userData.weapons.Add(main1);
            SetUp(WeaponSlotType.Main1, main1);

            Equipment main2 = new Equipment();
            main2.key = WeaponType.SMG.ToString();
            main2.setUpType = WeaponSlotType.Main2;
            userData.weapons.Add(main2);
            SetUp(WeaponSlotType.Main2, main2);

            Equipment sub = new Equipment();
            sub.key = WeaponType.HG.ToString();
            sub.setUpType = WeaponSlotType.Sub;
            userData.weapons.Add(sub);
            SetUp(WeaponSlotType.Sub, sub);

            AddItem(AmmoType.AR.ToString(), 100);
            AddItem(AmmoType.SMG.ToString(), 100);
            // 초기 골드, 무기 키 등 추가 데이터 설정 가능
            // userData.gold = 100;
            // userData.weaponkey = "Pistol";

            // 생성된 초기 데이터를 저장합니다.
            SaveManager.SaveData("UserData", userData);
        }
    }

    //게임 시작 시 호출되며, 저장된 유저 데이터를 불러오거나 초기화
    private void Start()
    {
        
    }

    // 디버그용 키 입력에 따라 아이템이나 무기를 추가합니다.
    private void Update()
    {
        // H 키를 누르면 새로운 아이템(UserItem)을 생성하여 userItems 리스트에 추가합니다.
        if (Input.GetKeyDown(KeyCode.H))
        {
            UserItem userItem = new UserItem();
            userItem.key = itemName;    // 입력된 아이템 이름을 key로 사용
            userItem.count = itemCount; // 입력된 아이템 개수를 할당

            userData.userItems.Add(userItem);
        }
        // J 키를 누르면 새로운 장비(Equipment)를 생성하여 weapons 리스트에 추가합니다.
        else if (Input.GetKeyDown(KeyCode.J))
        {
            Equipment equipment = new Equipment();
            equipment.key = itemName;   // 입력된 아이템 이름을 key로 사용
            // 필요한 경우 setup 값 등 추가 초기화할 수 있음

            userData.weapons.Add(equipment);
        }
    }

    // 유저가 장착한 무기 중 setup 값이 true인 무기를 찾아 반환합니다.
    public Equipment GetSetUpWeapon(WeaponSlotType type)
    {   
        // 유저가 보유한 무기 리스트를 순회합니다.
        for (int i = 0; i < userData.weapons.Count; i++)
        {
            // 만약 해당 무기가 현재 장착된 상태라면 반환합니다.
            if (userData.weapons[i].setUpType == type)
            {
                return userData.weapons[i];
            }
        }
        // 장착된 무기가 없으면 null 반환
        return null;
    }

    public void SetUp(WeaponSlotType setUpType, Equipment equipment)
    {
        Equipment setUpE = GetSetUpWeapon(setUpType);
        if (setUpE != null)
        {
            setUpE.setUpType = WeaponSlotType.None;
        }
        equipment.setUpType = setUpType;
        
    }


    // 특정 key를 가진 아이템의 개수를 추가하는 메서드입니다.
    public void AddItem(string key, int count)
    {
        // key에 해당하는 아이템을 가져오거나, 없으면 새로 생성합니다.
        UserItem userItem = GetUesrItem(key);
        // 해당 아이템의 개수를 증가시킵니다.
        userItem.count += count;
        // 변경된 유저 데이터를 파일에 저장합니다.
        SaveManager.SaveData("UserData", userData);
    }

    // 특정 key를 가진 UserItem을 반환합니다.
    // 만약 해당 아이템이 존재하지 않으면 새로 생성하여 userItems 리스트에 추가합니다.
    public UserItem GetUesrItem(string key)
    {
        // 보유한 모든 아이템을 순회합니다.
        for (int i = 0; i < userData.userItems.Count; i++)
        {
            // key가 일치하는 아이템이 있으면 반환합니다.
            if (key == userData.userItems[i].key)
            {
                return userData.userItems[i];
            }
        }
        // 일치하는 아이템이 없으면 새 UserItem 생성
        UserItem userItem = new UserItem();
        userItem.key = key;
        userItem.count = 0;

        // 생성한 아이템을 userItems 리스트에 추가한 후 반환합니다.
        userData.userItems.Add(userItem);
        return userItem;
    }
}

// 유저의 기본 데이터를 저장하는 클래스입니다.
[System.Serializable]
public class UserData
{
    // 유저의 닉네임
    public string nickname;
    // 유저가 보유한 골드
    public int gold;

    public int[] currentAmmoSlot = new int[4];

    public WeaponSlotType currentSlot = WeaponSlotType.Main1;

    // 유저가 소유한 아이템 리스트
    public List<UserItem> userItems = new List<UserItem>();
    // 유저가 보유한 무기 리스트 (보유 무기)
    public List<Equipment> weapons = new List<Equipment>();
    // 유저가 보유한 기타 장비 리스트 (보유 장비)
    public List<Equipment> gears = new List<Equipment>();
}

// 유저가 보유한 개별 아이템 정보를 저장하는 클래스입니다.
[System.Serializable]
public class UserItem
{
    // 아이템을 식별하기 위한 고유 key (예: 아이템 이름 또는 ID)
    public string key;
    // 보유한 아이템의 개수
    public int count;
}

// 유저의 장비 정보를 저장하는 클래스입니다.
[System.Serializable]
public class Equipment
{
    // 장비를 식별하기 위한 고유 key
    public string key;
    // 해당 장비가 현재 장착되어 있는지 여부
    
    // 해당 장비가 장착 된 슬롯
    public WeaponSlotType setUpType ;


    // 장비에 부착된 부품들의 key 목록 (부품 정보를 참조하기 위한 리스트)
    public List<string> partKeys = new List<string>();
}

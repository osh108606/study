using UnityEngine;

// WeaponManager 클래스는 WeaponInfo를 상속받으며, 무기 관련 데이터를 관리하는 역할을 합니다.
public class WeaponManager : WeaponInfo
{
    // 현재 선택된 무기 정보를 저장하는 변수
    public WeaponInfo Weaponinfo;

    // 싱글톤(Singleton) 패턴을 위한 정적 인스턴스 변수
    public static WeaponManager Instance;

    // 인스턴스 생성 시 호출되는 Awake 메서드 (싱글톤 인스턴스 초기화)
    private void Awake()
    {
        Instance = this;
    }

    // 여러 무기 정보를 저장하는 배열 (Inspector에서 할당)
    public WeaponInfo[] weaponInfos;

    // 게임 시작 시 호출되는 Start 메서드
    private void Start()
    {
        // 예시: HG 타입 무기 정보를 배열에서 찾아 할당
        Weaponinfo = GetWeaponData(WeaponType.HG);
    }

    // 특정 무기 타입에 해당하는 무기 정보를 찾아 반환하는 메서드
    public WeaponInfo GetWeaponData(WeaponType weaponType)
    {
        // weaponInfos 배열을 순회하며
        for (int i = 0; i < weaponInfos.Length; i++)
        {
            // 만약 현재 무기 정보의 타입이 인자로 전달된 weaponType과 일치하면
            if (weaponInfos[i].weaponType == weaponType)
            {
                // 해당 무기 정보를 현재 무기 정보 변수에 저장하고 반환
                Weaponinfo = weaponInfos[i];
                return Weaponinfo;
            }
        }
        // 일치하는 무기 정보가 없을 경우 null 반환
        return null;
    }
}

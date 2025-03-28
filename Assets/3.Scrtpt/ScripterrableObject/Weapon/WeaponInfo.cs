using UnityEngine;

// ScriptableObject를 상속받아 에디터에서 무기 정보를 쉽게 관리할 수 있도록 하는 클래스입니다.
// [CreateAssetMenu] 어트리뷰트를 통해 에셋 생성 메뉴에 표시됩니다.
[CreateAssetMenu(fileName = "WeaponInfo", menuName = "Scriptable Objects/WeaponInfo")]
public class WeaponInfo : ScriptableObject
{
    // 무기의 종류를 지정 (예: 권총, 소총 등)
    public WeaponType weaponType;

    // 무기의 사용 타입 (예: 메인, 서브, 스페셜 등)
    public WeaponUseType weaponUse;

    // 무기에 장착 가능한 부품의 타입 배열 (예: 스코프, 총열 등)
    public WeaponPartType[] partTypes;

    // 무기의 등급 (예: 보통, 희귀, 전설 등)
    public Grade grade;

    // 추후 고려할 추가 옵션들
    // public int weapondamage;     // 무기 기본 데미지 (추가 고려 중)
    // public int substat;          // 보조 능력치 1 (추가 고려 중)
    // public int randumsubstat;    // 보조 능력치 2 (랜덤 보정치, 추가 고려 중)

    // 무기의 기본 데미지
    public float baseDamage;

    // 분당 발사 횟수 (Rounds Per Minute, RPM)
    public float RPM;

    // 무기의 명중률 (에임 시 크로스헤어의 크기와 벌어짐 정도로 판단)
    public float accuracy;

    // 무기의 안정성 (반동 정도: 마우스가 위로 올라가는 크기)
    public float stability;

    // 재장전 속도 (초 단위)
    public float reloadSpeed;

    // 치명타 확률 (추가 고려 중)
    // public int CriticalChance;

    // 치명타 데미지 (추가 고려 중)
    // public int CriticalDamage;

    // 헤드샷 시 추가 데미지
    public int HeadshotDamage;

    // 탄창에 들어가는 최대 탄약 수
    public int cilpammo;

    // 자동 발사 여부 (true면 연속 발사가 가능)
    public bool automaticFire;

    // 무기 썸네일 이미지 (에디터나 UI에서 사용)
    public Sprite thum;

    // 무기 일러스트 이미지
    public Sprite illustrat;

    // 무기 관련 단축키나 추가 정보를 문자열로 저장
    public string shortcutInfo;
}

// 무기의 종류를 나타내는 열거형 (예: HG: 권총, SMG: 기관단총, AR: 돌격소총 등)
public enum WeaponType
{
    HG,   // 핸드건 (권총)
    SMG,  // 기관단총
    AR,   // 돌격소총
    SG,   // 산탄총
    RF,   // 돌격소총 계열(또는 소총)
    SR,   // 저격소총
    MG,   // 기관총
    HW    // 중화기
}

// 무기의 사용 슬롯 및 타입을 나타내는 열거형
public enum WeaponUseType
{
    Main1 = 0,   // 주 무기 1
    Main2,       // 주 무기 2
    sub,         // 보조 무기
    special = 4  // 특수 무기 (특정 슬롯 번호 4 할당)
}

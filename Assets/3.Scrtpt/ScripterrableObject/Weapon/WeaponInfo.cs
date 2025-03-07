using UnityEngine;

[CreateAssetMenu(fileName = "WeaponInfo", menuName = "Scriptable Objects/WeaponInfo")]
public class WeaponInfo : ScriptableObject
{
    public WeaponType weaponType;
    public  WeaponUseType WeaponUse;
    public Grade grade;
    //?=넣을지 고려중or여기에 넣는건지 모름
    //무기데미지? public int weapondamage;
    //보조속성1? public int substat;
    //랜덤보조속성2? public int randumsubstat;
    public float baseDamage;
    public float RPM;           //분당 발사횟수
    public float accuracy;      //명중율(에임:크로스헤어가 크기& 벌어지는 양)
    public float stability;     //안정성(반동:마우스가 올라가는 크기)
    public float reloadSpeed;
    //치명타확율? public int CriticalChance
    //치명타 데미지? public int CriticalDamage
    public int HeadshotDamage;  //헤드샷 데미지
    
    public int cilpammo;        //현탄창 양
    public bool automaticFire;  //자동발사여부
    public Sprite thum;         //썸네일
    public Sprite illustrat;    //스프라이트
}

//무기 종류타입
public enum WeaponType
{
    HG,
    SMG,
    AR,
    SG,
    RF,
    SR,
    MG,
    HW
}

//무기 슬롯및 무기 유형
public enum WeaponUseType
{
    Main1 = 0,
    Main2,
    sub,
    special = 4
}
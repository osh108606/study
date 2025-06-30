using UnityEngine;

//무기 부착물 정보
public class WeaponPart : MonoBehaviour
{
    public WeaponPartType weaponPartType; // 무기 부착물 타입
    public float damage;
    public float accuracy;
    public float stability;
    public int cilpammo;
}


public enum WeaponPartType//무기 부착물 타입
{
    Muzzle,
    Magazine,
    sight,
    Upper_Barrel,
    Lower_Barrel,
    Left_Barrel,
    Right_Barrel,
    Stock

}
using UnityEngine;

public class WeaponPart : MonoBehaviour
{
    public WeaponPartType weaponPartType;
    public float damage;
    public float accuracy;
    public float stability;
    public int cilpammo;
}


public enum WeaponPartType
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
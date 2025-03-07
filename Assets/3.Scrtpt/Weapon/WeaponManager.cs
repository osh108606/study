using UnityEngine;

public class WeaponManager : WeaponInfo
{
    public WeaponInfo Weaponinfo;
    public static WeaponManager Instance;
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



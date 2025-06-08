using TMPro;
using UnityEngine;

public class WeaponStatusPanel : MonoBehaviour
{
    public TMP_Text currentMagzinText;
    public TMP_Text ownMagzinText;

    Ammo ammo;
    public void Equiped()
    {
        ammo = User.Instance.GetUesrAmmo(Player.Instance.curweapon.weaponInfo.ammoType);
      
    }

    void Update()
    {
        if(Player.Instance == null)
        {
            currentMagzinText.gameObject.SetActive(false);
            ownMagzinText.gameObject.SetActive(false );
            return;
        }

        currentMagzinText.gameObject.SetActive(true);
        ownMagzinText.gameObject.SetActive(true);

        int slotIndex = (int)User.Instance.userData.currentSlot;
        currentMagzinText.text = User.Instance.userData.currentAmmoSlot[slotIndex].ToString();

        

        ownMagzinText.text = ammo.count.ToString();

    }
}

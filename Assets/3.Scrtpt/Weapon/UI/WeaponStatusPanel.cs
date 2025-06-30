using TMPro;
using UnityEngine;

public class WeaponStatusPanel : MonoBehaviour
{
    public TMP_Text currentMagzinText; // 현 탄창량
    public TMP_Text ownMagzinText; // 소지 탄약량

    Ammo ammo;
    public void Equiped()
    {
        ammo = User.Instance.GetUesrAmmo(Player.Instance.curweapon.weaponInfo.weaponType);
    }

    void Update()
    {
        //플레이어가 없으면 비활성화
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

        
        if(User.Instance.userData.currentSlot != WeaponSlotType.Sub)
        {
            ownMagzinText.text = ammo.count.ToString();
        }
        else
        {
            ownMagzinText.text = "00";
        }
        

    }
}

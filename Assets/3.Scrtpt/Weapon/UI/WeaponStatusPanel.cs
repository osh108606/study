using TMPro;
using UnityEngine;

public class WeaponStatusPanel : MonoBehaviour
{
    public TMP_Text currentMagzinText;
    public TMP_Text ownMagzinText;

    UserItem userItem;
    public void Equiped()
    {
        userItem = User.Instance.GetUesrItem(Player.Instance.curweapon.weaponInfo.ammoType.ToString());
      
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

        

        ownMagzinText.text = userItem.count.ToString();

    }
}

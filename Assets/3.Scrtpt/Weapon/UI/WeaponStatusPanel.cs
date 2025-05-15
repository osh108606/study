using TMPro;
using UnityEngine;

public class WeaponStatusPanel : MonoBehaviour
{
    public TMP_Text currentMagzinText;
    public TMP_Text ownMagzinText;
    // Update is called once per frame
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

        WeaponInfo info = Player.Instance.curweapon.weaponInfo;
        ownMagzinText.text = info.cilpammo.ToString();

    }
}

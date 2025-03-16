using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq; //집합 자료구조 기능 확장: 리스트 배열 딕셔너리
public class WeaponInfoContainer : MonoBehaviour
{
    public TMP_Text weaponNametext;
    public TMP_Text weaponInfotext;
    public Image weaponImage;

    public WeaponPartButton[] partButtons;

    public void UpdateContainer()
    {
        string setupWeaponKey = User.Instance.userData.equipment.key;
        //배열에 접근한 이유?
        WeaponItemData weaponItemData = ItemManager.Instance.GetWeaponItemData(setupWeaponKey);
        weaponImage.sprite = weaponItemData.thum;
        weaponNametext.text = weaponItemData.name;
        weaponInfotext.text = weaponItemData.WeaponInfo.shortcutInfo;

        //partButtons
        WeaponPartType[] weaponPartTypes = weaponItemData.WeaponInfo.partTypes;
        for (int i = 0; i < partButtons.Length; i++)
        {
            if (weaponPartTypes.Contains(partButtons[i].partType))
            {
                partButtons[i].gameObject.SetActive(true);
            }
            else
            {
                partButtons[i].gameObject.SetActive(false);
            }
        }
    }
}

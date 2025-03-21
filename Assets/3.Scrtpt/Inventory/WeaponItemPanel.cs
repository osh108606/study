using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponItemPanel : MonoBehaviour
{
    public Image thumImage;
    public TMP_Text nameText;

    public void SetWeapon(Equipment equipment)
    {
        WeaponItemData data = ItemManager.Instance.GetWeaponItemData(equipment.key);
        thumImage.sprite = data.thum;
        nameText.text = data.name;
    }
}

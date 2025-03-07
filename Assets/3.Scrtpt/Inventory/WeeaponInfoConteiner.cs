using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class WeeaponInfoConteiner : MonoBehaviour
{
    public TMP_Text weaponNametext;
    public Image weaponImage;

    public void UpdateContainer()
    {
        for (int i = 0; i < ItemManager.Instance.gearItemDatas.Length; i++)
        {
            if (ItemManager.Instance.gearItemDatas[i].key == User.Instance.userData.weaponkey)
            {

            }       
        } 
         
         
    }
}

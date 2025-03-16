using TMPro;
using UnityEngine;

public class WeaponInventoryCanvase : MonoBehaviour
{
    //무기 인벤토리 창
    //유저가 가지고있는 "무기" 이미지 데미지 
    //현재 장착하고있는 아이템
    //간략한 정보
    //가지고있는 아이템들
    public ItemPanel itemPanePrefab;
    public Transform contentTr;
    

    void Start()
    {
        string setupWeaponkey = User.Instance.userData.equipments.
        
        for(int i=0; i< User.Instance.userData.equipments.Count; i++)
        {
            if(setupWeaponkey != ItemManager.Instance.weaponItemDatas[i].key)
            {
                continue;
            }
            ItemPanel Panel = Instantiate(itemPanePrefab, contentTr);
            Panel.SetUserItem(User.Instance.userData.equipments[i]);
        }
    }

    void WeaponUpdate()
    {
        

        
            //ItemPanel Panel = Instantiate(itemPanePrefab, contentTr);
            //Panel.SetUserItem(User.Instance.userData.userItems[i]);
    }
}

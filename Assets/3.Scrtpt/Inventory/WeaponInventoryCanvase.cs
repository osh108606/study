using TMPro;
using UnityEngine;

public class WeaponInventoryCanvase : MonoBehaviour
{
    //���� �κ��丮 â
    //������ �������ִ� "����" �̹��� ������ 
    //���� �����ϰ��ִ� ������
    //������ ����
    //�������ִ� �����۵�
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

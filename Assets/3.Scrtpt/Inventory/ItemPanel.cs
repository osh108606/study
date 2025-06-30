using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPanel : MonoBehaviour
{
    // 인벤토리에 나올 인벤토리의 무기표기ui에들어갈 코드
    public TMP_Text m_Text;//이름
    public Image thumImage;//썸네일
    public virtual void SetUserItem(UserItem userItem)
    {
        //for (int i = 0; i < ItemManager.Instance.itemDatas.Length; i++)
        //{
        //    if (ItemManager.Instance.itemDatas[i].key == userItem.key)
        //    {
        //        thumImage.sprite = ItemManager.Instance.itemDatas[i].thum;
        //        if (ItemManager.Instance.itemDatas[i].itemType == ItemType.Consume)
        //        {
        //            m_Text.text = userItem.count.ToString();//?
        //        }
        //        else if (ItemManager.Instance.itemDatas[i].itemType == ItemType.Gear)
        //        {
        //            m_Text.text = ItemManager.Instance.itemDatas[i].name;
        //        }

        //        break;
        //    }
        //}
    }
    public void SetUserItem(Equipment equipment)
    {
        //for (int i = 0; i < ItemManager.Instance.itemDatas.Length; i++)
        //{
        //    if (ItemManager.Instance.itemDatas[i].key == userItem.key)
        //    {
        //        thumImage.sprite = ItemManager.Instance.itemDatas[i].thum;
        //        if (ItemManager.Instance.itemDatas[i].itemType == ItemType.Consume)
        //        {
        //            m_Text.text = userItem.count.ToString();//?
        //        }
        //        else if (ItemManager.Instance.itemDatas[i].itemType == ItemType.Gear)
        //        {
        //            m_Text.text = ItemManager.Instance.itemDatas[i].name;
        //        }

        //        break;
        //    }
        //}
    }
}

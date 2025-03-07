using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPanel : MonoBehaviour
{
    public TMP_Text m_Text;
    public Image thumImage;
    public void SetUserItem(UserItem userItem)
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

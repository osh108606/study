using System.Net.NetworkInformation;
using UnityEngine;

public class InventoyCanvas : MonoBehaviour
{
    public ItemPanel itemPanePrefab;
    public Transform contentTr;
    private void Start()
    {
        
        for(int i = 0; i< User.Instance.userData.userItems.Count;i++)
        {
            if (User.Instance.userData.userItems[i].count <= 0)
                continue;
            ItemPanel Panel = Instantiate(itemPanePrefab,contentTr);
            Panel.SetUserItem(User.Instance.userData.userItems[i]);
        }
    }
}

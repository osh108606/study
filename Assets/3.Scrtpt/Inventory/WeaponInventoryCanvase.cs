using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponInventoryCanvase : MonoBehaviour
{
    //���� �κ��丮 â
    //������ �������ִ� "����" �̹��� ������ 
    //���� �����ϰ��ִ� ������
    //������ ����
    //�������ִ� �����۵�
    public WeaponItemPanel itemPanePrefab;
    public Transform contentTr;

    List<WeaponItemPanel> panels = new List<WeaponItemPanel>();
    private void OnEnable()
    {
        for(int i = 0; i < panels.Count; i++)
        {
            panels[i].gameObject.SetActive(false);
        }
        for(int i=0; i< User.Instance.userData.weapons.Count; i++)
        {
            WeaponItemPanel Panel = GetWeaponItemPanelInPool();
            Panel.SetWeapon(User.Instance.userData.weapons[i]);
        }
    }

    public WeaponItemPanel GetWeaponItemPanelInPool()
    {
        for (int i = 0; i < panels.Count; i++)
        {
            if (panels[i].gameObject.activeSelf)
            {
                continue;
            }
            panels[i].gameObject.SetActive(true);
            return panels[i];
        }
        WeaponItemPanel panel =Instantiate(itemPanePrefab, contentTr);
        panels.Add (panel);
        return panel;
    }
}

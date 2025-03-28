using System.Collections.Generic;
using TMPro; // TextMeshPro ���� ����� ����ϱ� ���� ���ӽ����̽� (���� �ڵ忡���� ���� �������� ����)
using UnityEngine;

// ���� �κ��丮 UI�� �����ϴ� Ŭ�����Դϴ�.
// ����ڰ� ������ ���⸦ UI �� ǥ���ϴ� ������ �մϴ�.
public class WeaponInventoryCanvase : MonoBehaviour
{
    // ���� ������ �г��� ������ (�� ���⸦ ǥ���� �� ����ϴ� ���ø�)
    public WeaponItemPanel itemPanePrefab;

    // ������ ������ �гε��� ��ġ�� �θ� Transform (��: ScrollView�� Content)
    public Transform contentTr;

    // ������ ���� ������ �гε��� �����ϰ� �����ϱ� ���� ����Ʈ (������Ʈ Ǯ�� �뵵)
    List<WeaponItemPanel> panels = new List<WeaponItemPanel>();

    // �ش� ������Ʈ�� Ȱ��ȭ�� �� ȣ��Ǵ� Unity �̺�Ʈ �޼���
    private void OnEnable()
    {
        // ������ ������ ��� �гε��� ��Ȱ��ȭ ���� �ʱ� ���·� ����ϴ�.
        for (int i = 0; i < panels.Count; i++)
        {
            panels[i].gameObject.SetActive(false);
        }

        // ����� �����Ϳ� ����� ���� ����Ʈ�� ��ȸ�մϴ�.
        for (int i = 0; i < User.Instance.userData.weapons.Count; i++)
        {
            // ������Ʈ Ǯ������ ��� ������ ���� ������ �г��� �����ɴϴ�.
            WeaponItemPanel Panel = GetWeaponItemPanelInPool();
            // �ش� �гο� ����� ���� �����͸� �����Ͽ� UI�� ���� ������ ǥ���մϴ�.
            Panel.SetWeapon(User.Instance.userData.weapons[i]);
        }

        // ���� ����ڰ� ������ ����(Equipment)�� ������ UI�� �ݿ��մϴ�.
        Equipment equipment = User.Instance.GetSetUpWeapon();
        SetEquipment(equipment);
    }

    // ������Ʈ Ǯ���� ��� ������ ���� ������ �г��� �������ų�, ������ ���� �����ϴ� �޼���
    public WeaponItemPanel GetWeaponItemPanelInPool()
    {
        for (int i = 0; i < panels.Count; i++)
        {
            if (panels[i].gameObject.activeSelf)
            {
                continue;
            }
            // ��� ������ �г��� Ȱ��ȭ�� �� ��ȯ�մϴ�.
            panels[i].gameObject.SetActive(true);
            return panels[i];
        }
        // ��� ������ �г��� ���ٸ�, �������� �ν��Ͻ�ȭ�Ͽ� �� �г��� �����մϴ�.
        WeaponItemPanel panel = Instantiate(itemPanePrefab, contentTr);
        // ������ �г��� ����Ʈ�� �߰��մϴ�.
        panels.Add(panel);
        return panel;
    }

    // ���� ������ ���� ������ UI�� �����ϴ� �޼���
    public void SetEquipment(Equipment equipment)
    {
        // �ڽ� ������Ʈ�� �ִ� WeaponInfoContainer ������Ʈ�� ã��, ������ ���� ������ �����մϴ�.
        GetComponentInChildren<WeaponInfoContainer>().SetEquipment(equipment);
    }
}

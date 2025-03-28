using System.Net.NetworkInformation;  // ��Ʈ��ũ ���� ����� ���� �߰��� ���ӽ����̽� (���� �ڵ忡���� ������ ����)
using UnityEngine;

// InventoyCanvas Ŭ������ �κ��丮 UI�� �����ϴ� ������ �մϴ�.
public class InventoyCanvas : MonoBehaviour
{
    // ������ �г� ������: �κ��丮 ������ �� �������� ǥ���� UI �г��� ���ø�
    public ItemPanel itemPanePrefab;

    // ������ �гε��� ��ġ�� �θ� Transform (���� ScrollView�� Content ��ü)
    public Transform contentTr;

    // ���� ���� �� ȣ��Ǵ� Start �޼���
    private void Start()
    {
        // User �ν��Ͻ��� userData�� ����� userItems ����Ʈ�� ��ȸ�մϴ�.
        for (int i = 0; i < User.Instance.userData.userItems.Count; i++)
        {
            // ���� �������� ������ 0 ���϶��, �ش� �������� ǥ������ �ʰ� �ǳʶݴϴ�.
            if (User.Instance.userData.userItems[i].count <= 0)
                continue;

            // ������ �г� �������� contentTr ������ �ν��Ͻ�ȭ�Ͽ� ���ο� ������ �г� ����
            ItemPanel Panel = Instantiate(itemPanePrefab, contentTr);
            // ������ ������ �гο� �ش� ������ �����͸� �����Ͽ� UI�� �����մϴ�.
            Panel.SetUserItem(User.Instance.userData.userItems[i]);
        }
    }
}

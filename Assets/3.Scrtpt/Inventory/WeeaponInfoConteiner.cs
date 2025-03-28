using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq; // ����Ʈ, �迭, ��ųʸ� ���� ���� �ڷᱸ���� Ȯ�� �޼���(��: Contains ��)�� ����

// ���� ���� UI �����̳� Ŭ����
// ���� ��� ���� �� ����(�̸�, �̹���, ���� ����)�� ���� ������ ��ǰ ��ư���� �����մϴ�.
public class WeaponInfoContainer : MonoBehaviour
{
    // ���� �̸��� ǥ���� TextMeshPro �ؽ�Ʈ ������Ʈ
    public TMP_Text weaponNametext;
    // ���⿡ ���� ���� ������ ǥ���� TextMeshPro �ؽ�Ʈ ������Ʈ
    public TMP_Text weaponInfotext;
    // ���� �̹����� ǥ���� UI �̹��� ������Ʈ
    public Image weaponImage;

    // ���� ��ǰ ���� ��ư �迭: �� ��ư�� Ư�� ��ǰ Ÿ���� ��ǥ�մϴ�.
    public WeaponPartButton[] partButtons;

    // ������ ���� ��� �����͸� UI�� �ݿ��ϴ� �޼���
    public void SetEquipment(Equipment equipment)
    {
        // ���޹��� ��� �������� ���� Ű�� ������
        string Key = equipment.key;

        // ������ �Ŵ����� ���� �ش� Ű�� �����ϴ� ���� ������ �����͸� ������
        WeaponItemData weaponItemData = ItemManager.Instance.GetWeaponItemData(Key);

        // ������ �����ͷ� UI ��ҵ��� ������Ʈ
        weaponImage.sprite = weaponItemData.thum;             // ���� ����� �̹��� ����
        weaponNametext.text = weaponItemData.name;            // ���� �̸� ����
        weaponInfotext.text = weaponItemData.WeaponInfo.shortcutInfo; // ���⿡ ���� ���� ����(����) ����

        //���� ������ �����ǰ ���̵��ϱ����ϱ�


        // ���⿡ ���� ������ ��ǰ Ÿ�Ե��� ������
        WeaponPartType[] weaponPartTypes = weaponItemData.WeaponInfo.partTypes;
        // �� ��ǰ ��ư�� ��ȸ�ϸ�, �ش� ���⿡ ��ǰ�� ���� �������� Ȯ�� �� UI ǥ�� ó��
        for (int i = 0; i < partButtons.Length; i++)
        {
            // ������ ��ǰ Ÿ�� ��Ͽ� ���� ��ư�� ��ǰ Ÿ���� ���ԵǾ� ������ ��ư Ȱ��ȭ
            if (weaponPartTypes.Contains(partButtons[i].partType))
            {
                partButtons[i].gameObject.SetActive(true);
            }
            else
            {
                // ���ԵǾ� ���� ������ ��ư ��Ȱ��ȭ
                partButtons[i].gameObject.SetActive(false);
            }
        }
    }

    // UI �����̳ʸ� ������Ʈ�ϱ� ���� �޼��� (���� ���� ����)
    public void UpdateContainer()
    {
        // ���� ����ڰ� ������ ������ Ű�� �������� �κ� (���÷� �ּ� ó���� �ڵ�)
        string setupWeaponKey = null; // User.Instance.userData.equipment.key;

        // ������ ���� Ű�� ���� ���� ������ �����͸� ���� (����� �߰� ������Ʈ ���� �̱���)
        WeaponItemData weaponItemData = ItemManager.Instance.GetWeaponItemData(setupWeaponKey);

        // ���� �߰����� UI ������Ʈ �۾��� �� �� ����
    }
}

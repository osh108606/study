using TMPro;       // TextMeshPro ���� ����� ����ϱ� ���� ���ӽ����̽�
using UnityEngine;
using UnityEngine.UI; // UI ���(��: Image)�� ����ϱ� ���� ���ӽ����̽�

// ���� ������ �г��� ��Ÿ���� Ŭ�����Դϴ�.
// �� �г��� ������ ����� �̹����� �̸�, �׸��� �ش� ��� �����͸� ǥ���մϴ�.
public class WeaponItemPanel : MonoBehaviour
{
    // ���� ������� ǥ���� UI �̹��� ������Ʈ
    public Image thumImage;

    // ���� �̸��� ǥ���� TextMeshPro �ؽ�Ʈ ������Ʈ
    public TMP_Text nameText;

    // �ش� �гο� ����� ���� ��� �����͸� �����ϴ� ����
    public Equipment equipment;

    // ���� �����͸� �гο� �����ϴ� �޼���
    public void SetWeapon(Equipment equipment)
    {
        // �Է¹��� ��� �����͸� Ŭ���� ���� ������ ����
        this.equipment = equipment;

        // ItemManager�� �̱��� �ν��Ͻ��� ����Ͽ�, �ش� ��� Ű�� ���� ���� ������ �����͸� ������
        WeaponItemData data = ItemManager.Instance.GetWeaponItemData(equipment.key);

        // ������ �������� ����� �̹����� �г��� �̹��� ������Ʈ�� �Ҵ�
        thumImage.sprite = data.thum;

        // ������ �������� �̸��� �г��� �ؽ�Ʈ ������Ʈ�� �Ҵ�
        nameText.text = data.name;
    }

    // �г��� Ŭ���Ǿ��� �� ȣ��Ǵ� �̺�Ʈ �޼���
    public void OnClickedPanel()
    {
        // �θ� ������Ʈ �� WeaponInventoryCanvase ������Ʈ�� ã��,
        // �ش� ������Ʈ�� SetEquipment �޼��带 ȣ���Ͽ� ���� �гο� ����� ��� �����ϵ��� ����
        GetComponentInParent<WeaponInventoryCanvase>().SetEquipment(equipment);
    }
}

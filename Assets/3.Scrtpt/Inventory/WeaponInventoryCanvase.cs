using System.Collections.Generic;
using TMPro; // TextMeshPro 관련 기능을 사용하기 위한 네임스페이스 (현재 코드에서는 직접 사용되지는 않음)
using UnityEngine;

// 무기 인벤토리 UI를 관리하는 클래스입니다.
// 사용자가 소유한 무기를 UI 상에 표시하는 역할을 합니다.
public class WeaponInventoryCanvase : MonoBehaviour
{
    // 무기 아이템 패널의 프리팹 (각 무기를 표현할 때 사용하는 템플릿)
    public WeaponItemPanel itemPanePrefab;

    // 생성된 아이템 패널들이 배치될 부모 Transform (예: ScrollView의 Content)
    public Transform contentTr;

    // 생성된 무기 아이템 패널들을 저장하고 관리하기 위한 리스트 (오브젝트 풀링 용도)
    List<WeaponItemPanel> panels = new List<WeaponItemPanel>();

    // 해당 오브젝트가 활성화될 때 호출되는 Unity 이벤트 메서드
    private void OnEnable()
    {
        // 기존에 생성된 모든 패널들을 비활성화 시켜 초기 상태로 만듭니다.
        for (int i = 0; i < panels.Count; i++)
        {
            panels[i].gameObject.SetActive(false);
        }

        // 사용자 데이터에 저장된 무기 리스트를 순회합니다.
        for (int i = 0; i < User.Instance.userData.weapons.Count; i++)
        {
            // 오브젝트 풀링에서 사용 가능한 무기 아이템 패널을 가져옵니다.
            WeaponItemPanel Panel = GetWeaponItemPanelInPool();
            // 해당 패널에 사용자 무기 데이터를 설정하여 UI에 무기 정보를 표시합니다.
            Panel.SetWeapon(User.Instance.userData.weapons[i]);
        }

        // 현재 사용자가 장착한 무기(Equipment)를 가져와 UI에 반영합니다.
        Equipment equipment = User.Instance.GetSetUpWeapon();
        SetEquipment(equipment);
    }

    // 오브젝트 풀에서 사용 가능한 무기 아이템 패널을 가져오거나, 없으면 새로 생성하는 메서드
    public WeaponItemPanel GetWeaponItemPanelInPool()
    {
        for (int i = 0; i < panels.Count; i++)
        {
            if (panels[i].gameObject.activeSelf)
            {
                continue;
            }
            // 사용 가능한 패널을 활성화한 후 반환합니다.
            panels[i].gameObject.SetActive(true);
            return panels[i];
        }
        // 사용 가능한 패널이 없다면, 프리팹을 인스턴스화하여 새 패널을 생성합니다.
        WeaponItemPanel panel = Instantiate(itemPanePrefab, contentTr);
        // 생성된 패널을 리스트에 추가합니다.
        panels.Add(panel);
        return panel;
    }

    // 현재 장착된 무기 정보를 UI에 설정하는 메서드
    public void SetEquipment(Equipment equipment)
    {
        // 자식 오브젝트에 있는 WeaponInfoContainer 컴포넌트를 찾아, 장착된 무기 정보를 갱신합니다.
        GetComponentInChildren<WeaponInfoContainer>().SetEquipment(equipment);
    }
}

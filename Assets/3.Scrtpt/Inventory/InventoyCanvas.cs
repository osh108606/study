using System.Net.NetworkInformation;  // 네트워크 관련 기능을 위해 추가된 네임스페이스 (현재 코드에서는 사용되지 않음)
using UnityEngine;

// InventoyCanvas 클래스는 인벤토리 UI를 관리하는 역할을 합니다.
public class InventoyCanvas : MonoBehaviour
{
    // 아이템 패널 프리팹: 인벤토리 내에서 각 아이템을 표시할 UI 패널의 템플릿
    public ItemPanel itemPanePrefab;

    // 아이템 패널들이 배치될 부모 Transform (보통 ScrollView의 Content 객체)
    public Transform contentTr;

    // 게임 시작 시 호출되는 Start 메서드
    private void Start()
    {
        // User 인스턴스의 userData에 저장된 userItems 리스트를 순회합니다.
        for (int i = 0; i < User.Instance.userData.userItems.Count; i++)
        {
            // 만약 아이템의 개수가 0 이하라면, 해당 아이템은 표시하지 않고 건너뜁니다.
            if (User.Instance.userData.userItems[i].count <= 0)
                continue;

            // 아이템 패널 프리팹을 contentTr 하위에 인스턴스화하여 새로운 아이템 패널 생성
            ItemPanel Panel = Instantiate(itemPanePrefab, contentTr);
            // 생성된 아이템 패널에 해당 아이템 데이터를 설정하여 UI를 갱신합니다.
            Panel.SetUserItem(User.Instance.userData.userItems[i]);
        }
    }
}

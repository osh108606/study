using TMPro;       // TextMeshPro 관련 기능을 사용하기 위한 네임스페이스
using UnityEngine;
using UnityEngine.UI; // UI 요소(예: Image)를 사용하기 위한 네임스페이스

// 무기 아이템 패널을 나타내는 클래스입니다.
// 각 패널은 무기의 썸네일 이미지와 이름, 그리고 해당 장비 데이터를 표시합니다.
public class WeaponItemPanel : MonoBehaviour
{
    // 무기 썸네일을 표시할 UI 이미지 컴포넌트
    public Image thumImage;

    // 무기 이름을 표시할 TextMeshPro 텍스트 컴포넌트
    public TMP_Text nameText;

    // 해당 패널에 연결된 무기 장비 데이터를 저장하는 변수
    public Equipment equipment;

    // 무기 데이터를 패널에 설정하는 메서드
    public void SetWeapon(Equipment equipment)
    {
        // 입력받은 장비 데이터를 클래스 내부 변수에 저장
        this.equipment = equipment;

        // ItemManager의 싱글톤 인스턴스를 사용하여, 해당 장비 키를 통해 무기 아이템 데이터를 가져옴
        WeaponItemData data = ItemManager.Instance.GetWeaponItemData(equipment.key);

        // 가져온 데이터의 썸네일 이미지를 패널의 이미지 컴포넌트에 할당
        thumImage.sprite = data.thum;

        // 가져온 데이터의 이름을 패널의 텍스트 컴포넌트에 할당
        nameText.text = data.name;
    }

    // 패널이 클릭되었을 때 호출되는 이벤트 메서드
    public void OnClickedPanel()
    {
        // 부모 오브젝트 중 WeaponInventoryCanvase 컴포넌트를 찾아,
        // 해당 컴포넌트의 SetEquipment 메서드를 호출하여 현재 패널에 연결된 장비를 장착하도록 설정
        GetComponentInParent<WeaponInventoryCanvase>().SetEquipment(equipment);
    }
}

using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq; // 리스트, 배열, 딕셔너리 등의 집합 자료구조에 확장 메서드(예: Contains 등)를 제공

// 무기 정보 UI 컨테이너 클래스
// 무기 장비에 대한 상세 정보(이름, 이미지, 간략 설명)와 장착 가능한 부품 버튼들을 관리합니다.
public class WeaponInfoContainer : MonoBehaviour
{
    // 무기 이름을 표시할 TextMeshPro 텍스트 컴포넌트
    public TMP_Text weaponNametext;
    // 무기에 대한 간략 정보를 표시할 TextMeshPro 텍스트 컴포넌트
    public TMP_Text weaponInfotext;
    // 무기 이미지를 표시할 UI 이미지 컴포넌트
    public Image weaponImage;

    // 무기 부품 선택 버튼 배열: 각 버튼은 특정 부품 타입을 대표합니다.
    public WeaponPartButton[] partButtons;

    // 선택한 무기 장비 데이터를 UI에 반영하는 메서드
    public void SetEquipment(Equipment equipment)
    {
        // 전달받은 장비 데이터의 고유 키를 가져옴
        string Key = equipment.key;

        // 아이템 매니저를 통해 해당 키에 대응하는 무기 아이템 데이터를 가져옴
        WeaponItemData weaponItemData = ItemManager.Instance.GetWeaponItemData(Key);

        // 가져온 데이터로 UI 요소들을 업데이트
        weaponImage.sprite = weaponItemData.thum;             // 무기 썸네일 이미지 설정
        weaponNametext.text = weaponItemData.name;            // 무기 이름 설정
        weaponInfotext.text = weaponItemData.WeaponInfo.shortcutInfo; // 무기에 대한 간략 정보(설명) 설정

        //현재 장착한 무기부품 보이도록구현하기


        // 무기에 장착 가능한 부품 타입들을 가져옴
        WeaponPartType[] weaponPartTypes = weaponItemData.WeaponInfo.partTypes;
        // 각 부품 버튼을 순회하며, 해당 무기에 부품이 장착 가능한지 확인 후 UI 표시 처리
        for (int i = 0; i < partButtons.Length; i++)
        {
            // 무기의 부품 타입 목록에 현재 버튼의 부품 타입이 포함되어 있으면 버튼 활성화
            if (weaponPartTypes.Contains(partButtons[i].partType))
            {
                partButtons[i].gameObject.SetActive(true);
            }
            else
            {
                // 포함되어 있지 않으면 버튼 비활성화
                partButtons[i].gameObject.SetActive(false);
            }
        }
    }

    // UI 컨테이너를 업데이트하기 위한 메서드 (추후 구현 예정)
    public void UpdateContainer()
    {
        // 현재 사용자가 설정한 무기의 키를 가져오는 부분 (예시로 주석 처리된 코드)
        string setupWeaponKey = null; // User.Instance.userData.equipment.key;

        // 설정된 무기 키를 통해 무기 아이템 데이터를 갱신 (현재는 추가 업데이트 로직 미구현)
        WeaponItemData weaponItemData = ItemManager.Instance.GetWeaponItemData(setupWeaponKey);

        // 이후 추가적인 UI 업데이트 작업이 들어갈 수 있음
    }
}

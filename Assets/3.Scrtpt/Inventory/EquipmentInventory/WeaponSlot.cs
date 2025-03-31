using UnityEngine;
using UnityEngine.UI;

public class WeaponSlot : EquipmentSlot
{
    public WeaponUseType weaponUseType;
    public WeaponSetUpType setUpType;
    //public WeaponInventoryCanvase weaponInventoryCanvase;
    private void Start()
    {
        Button b = GetComponent<Button>();
        b.onClick.AddListener(OnClickedSlot);
    }

    public void OnClickedSlot()
    {
        WeaponInventoryCanvase.Instance.OpenWeaponInventory(weaponUseType, setUpType);

        //WeaponInventoryCanvase canvas = FindFirstObjectByType<WeaponInventoryCanvase>(FindObjectsInactive.Include);
        //canvas.OpenWeaponInventory(weaponUseType);


        //과제
        //WeaponInventoryCanvas 컴포넌트의 OpenWeaponInventory()함수 호출하면서 weaponUseType전달
        //WeaponInventoryCanvas에서 유저가 가지고 있는 무기 들중 weaponUseType에 맞는 무기만 리스트업되면서
        //클릭하면서 장착 해제할 수 있게 처리하기
    }
}

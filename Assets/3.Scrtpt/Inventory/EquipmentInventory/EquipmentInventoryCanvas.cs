using UnityEngine;

public class EquipmentInventoryCanvas : MonoBehaviour
{
    private static EquipmentInventoryCanvas instance;
    public static EquipmentInventoryCanvas Instance
    {
        get
        {
            if (instance == null)
                instance = FindFirstObjectByType<EquipmentInventoryCanvas>(FindObjectsInactive.Include);

            return instance;
        }

    }

}

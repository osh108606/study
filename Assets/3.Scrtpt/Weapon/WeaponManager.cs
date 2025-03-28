using UnityEngine;

// WeaponManager Ŭ������ WeaponInfo�� ��ӹ�����, ���� ���� �����͸� �����ϴ� ������ �մϴ�.
public class WeaponManager : WeaponInfo
{
    // ���� ���õ� ���� ������ �����ϴ� ����
    public WeaponInfo Weaponinfo;

    // �̱���(Singleton) ������ ���� ���� �ν��Ͻ� ����
    public static WeaponManager Instance;

    // �ν��Ͻ� ���� �� ȣ��Ǵ� Awake �޼��� (�̱��� �ν��Ͻ� �ʱ�ȭ)
    private void Awake()
    {
        Instance = this;
    }

    // ���� ���� ������ �����ϴ� �迭 (Inspector���� �Ҵ�)
    public WeaponInfo[] weaponInfos;

    // ���� ���� �� ȣ��Ǵ� Start �޼���
    private void Start()
    {
        // ����: HG Ÿ�� ���� ������ �迭���� ã�� �Ҵ�
        Weaponinfo = GetWeaponData(WeaponType.HG);
    }

    // Ư�� ���� Ÿ�Կ� �ش��ϴ� ���� ������ ã�� ��ȯ�ϴ� �޼���
    public WeaponInfo GetWeaponData(WeaponType weaponType)
    {
        // weaponInfos �迭�� ��ȸ�ϸ�
        for (int i = 0; i < weaponInfos.Length; i++)
        {
            // ���� ���� ���� ������ Ÿ���� ���ڷ� ���޵� weaponType�� ��ġ�ϸ�
            if (weaponInfos[i].weaponType == weaponType)
            {
                // �ش� ���� ������ ���� ���� ���� ������ �����ϰ� ��ȯ
                Weaponinfo = weaponInfos[i];
                return Weaponinfo;
            }
        }
        // ��ġ�ϴ� ���� ������ ���� ��� null ��ȯ
        return null;
    }
}

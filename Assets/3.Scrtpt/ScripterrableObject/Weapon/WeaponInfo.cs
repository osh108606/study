using UnityEngine;

// ScriptableObject�� ��ӹ޾� �����Ϳ��� ���� ������ ���� ������ �� �ֵ��� �ϴ� Ŭ�����Դϴ�.
// [CreateAssetMenu] ��Ʈ����Ʈ�� ���� ���� ���� �޴��� ǥ�õ˴ϴ�.
[CreateAssetMenu(fileName = "WeaponInfo", menuName = "Scriptable Objects/WeaponInfo")]
public class WeaponInfo : ScriptableObject
{
    // ������ ������ ���� (��: ����, ���� ��)
    public WeaponType weaponType;

    // ������ ��� Ÿ�� (��: ����, ����, ����� ��)
    public WeaponUseType weaponUse;

    // ���⿡ ���� ������ ��ǰ�� Ÿ�� �迭 (��: ������, �ѿ� ��)
    public WeaponPartType[] partTypes;

    // ������ ��� (��: ����, ���, ���� ��)
    public Grade grade;

    // ���� ����� �߰� �ɼǵ�
    // public int weapondamage;     // ���� �⺻ ������ (�߰� ��� ��)
    // public int substat;          // ���� �ɷ�ġ 1 (�߰� ��� ��)
    // public int randumsubstat;    // ���� �ɷ�ġ 2 (���� ����ġ, �߰� ��� ��)

    // ������ �⺻ ������
    public float baseDamage;

    // �д� �߻� Ƚ�� (Rounds Per Minute, RPM)
    public float RPM;

    // ������ ���߷� (���� �� ũ�ν������ ũ��� ������ ������ �Ǵ�)
    public float accuracy;

    // ������ ������ (�ݵ� ����: ���콺�� ���� �ö󰡴� ũ��)
    public float stability;

    // ������ �ӵ� (�� ����)
    public float reloadSpeed;

    // ġ��Ÿ Ȯ�� (�߰� ��� ��)
    // public int CriticalChance;

    // ġ��Ÿ ������ (�߰� ��� ��)
    // public int CriticalDamage;

    // ��弦 �� �߰� ������
    public int HeadshotDamage;

    // źâ�� ���� �ִ� ź�� ��
    public int cilpammo;

    // �ڵ� �߻� ���� (true�� ���� �߻簡 ����)
    public bool automaticFire;

    // ���� ����� �̹��� (�����ͳ� UI���� ���)
    public Sprite thum;

    // ���� �Ϸ���Ʈ �̹���
    public Sprite illustrat;

    // ���� ���� ����Ű�� �߰� ������ ���ڿ��� ����
    public string shortcutInfo;
}

// ������ ������ ��Ÿ���� ������ (��: HG: ����, SMG: �������, AR: ���ݼ��� ��)
public enum WeaponType
{
    HG,   // �ڵ�� (����)
    SMG,  // �������
    AR,   // ���ݼ���
    SG,   // ��ź��
    RF,   // ���ݼ��� �迭(�Ǵ� ����)
    SR,   // ���ݼ���
    MG,   // �����
    HW    // ��ȭ��
}

// ������ ��� ���� �� Ÿ���� ��Ÿ���� ������
public enum WeaponUseType
{
    Main1 = 0,   // �� ���� 1
    Main2,       // �� ���� 2
    sub,         // ���� ����
    special = 4  // Ư�� ���� (Ư�� ���� ��ȣ 4 �Ҵ�)
}

using UnityEngine;

[CreateAssetMenu(fileName = "WeaponInfo", menuName = "Scriptable Objects/WeaponInfo")]
public class WeaponInfo : ScriptableObject
{
    public WeaponType weaponType;
    public  WeaponUseType WeaponUse;
    public Grade grade;
    //?=������ �����or���⿡ �ִ°��� ��
    //���ⵥ����? public int weapondamage;
    //�����Ӽ�1? public int substat;
    //���������Ӽ�2? public int randumsubstat;
    public float baseDamage;
    public float RPM;           //�д� �߻�Ƚ��
    public float accuracy;      //������(����:ũ�ν��� ũ��& �������� ��)
    public float stability;     //������(�ݵ�:���콺�� �ö󰡴� ũ��)
    public float reloadSpeed;
    //ġ��ŸȮ��? public int CriticalChance
    //ġ��Ÿ ������? public int CriticalDamage
    public int HeadshotDamage;  //��弦 ������
    
    public int cilpammo;        //��źâ ��
    public bool automaticFire;  //�ڵ��߻翩��
    public Sprite thum;         //�����
    public Sprite illustrat;    //��������Ʈ
}

//���� ����Ÿ��
public enum WeaponType
{
    HG,
    SMG,
    AR,
    SG,
    RF,
    SR,
    MG,
    HW
}

//���� ���Թ� ���� ����
public enum WeaponUseType
{
    Main1 = 0,
    Main2,
    sub,
    special = 4
}
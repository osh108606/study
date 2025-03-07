using UnityEngine;

[CreateAssetMenu(fileName = "EnemyInfo", menuName = "Scriptable Objects/EnemyInfo")]
public class EnemyInfo : ScriptableObject
{
    public EnemyType enemyType;
    public Enemyfaction enemyfaction;
    public float Maxhp;
    public float moveSpeed;
    public float attackDamage;
    public float attackRange;
    public float stopDistance;
    public float findrange;
    public float attackdelay;
}

//적 공격 유형
public enum EnemyType
{
    Melee,
    Ranged
}

//적 팩션 유형
public enum Enemyfaction
{

    faction1,
    faction2,
    faction3,
    faction4,
    faction5,
    faction6

}
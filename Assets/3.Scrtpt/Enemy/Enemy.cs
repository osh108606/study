using UnityEngine;

public enum Enemystate
{
    Idle,
    Approching,
    Attack
}
//적 피격부위
public enum BodyPart
{
    Head,
    Body,
    Leg
}
public class Enemy : MonoBehaviour
{

    public Enemystate enemystate;
    public EnemyInfo enemyInfo;
    //public BodyPart bodyPart;
    public float hp;
    
    
    
    public BoxCollider2D[] boxCollider2D;
    void EnterState(Enemystate enemystate)
    {
        this.enemystate = enemystate;
    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

        EnterState(Enemystate.Idle);
    }
    public float attackTimer = 0;
    void Update()
    {
        
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;
        if(enemystate == Enemystate.Idle)
        {
            float distance = Vector2.Distance(transform.position, Player.Instance.transform.position);
            
            if(distance <= enemyInfo.findrange)
            {
                EnterState(Enemystate.Approching);
            }
        }
        
        if (enemystate == Enemystate.Approching)
        {
            float distance = Vector2.Distance(transform.position, Player.Instance.transform.position);
            Vector2 result = Vector2.MoveTowards(transform.position, Player.Instance.transform.position, Time.deltaTime * enemyInfo.moveSpeed);
            transform.position = result;
            if (Player.Instance.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else if(Player.Instance.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector2(1, 1);
            }

            if(distance <= enemyInfo.attackRange)
            {
                EnterState(Enemystate.Attack);
            }
            else if(distance > enemyInfo.findrange)
            {
                EnterState(Enemystate.Idle);
            }
        }
        else if (enemystate == Enemystate.Attack)
        {
            
            if (Player.Instance.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else if (Player.Instance.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector2(1, 1);
            }
            if (attackTimer<=0)
            {
                Attack();
                attackTimer = enemyInfo.attackdelay;
                EnterState(Enemystate.Idle);
            }
                   
        }
    }
    public virtual void Attack()
    {
       
    }
}

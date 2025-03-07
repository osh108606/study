using Unity.VisualScripting;
using UnityEngine;



public class Player : MonoBehaviour, IHittable
{
    public static Player Instance;
    public Transform Headtr;
    public Transform Bodytr;
    public float hp = 0;
    public float moveSpeed;
    public Rigidbody2D rb2d;
    public Weapon[] weapons;
    public WeaponUseType curweapon;
    
    MainInputSystem inputAction;

    private void Awake()
    {
        inputAction = new MainInputSystem();
        

        Instance = this;
        Debug.Log("Awake");
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }
    private void Start()
    {
        
        Equipt(0);
        Debug.Log("Start");
    }
    public void TakeDamage(float damage)
    {

        hp -= damage;
        Debug.Log(hp);
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Equipt(int idx)//intÇü
    {
        
        for (WeaponUseType i = (WeaponUseType)0; i < (WeaponUseType)5; i++)//enumÇü
        {
            if (i == (WeaponUseType) idx)//enumÇü
            {
                curweapon = (WeaponUseType)i;
                weapons[(int)i].gameObject.SetActive(true);
            }
            else
            {
                weapons[(int)i].gameObject.SetActive(false);
            }

        }
        
    }
    void Movement()
    { 
        Vector2 moveVec = inputAction.Ground.Move.ReadValue<Vector2>();
        rb2d.linearVelocity = moveVec.normalized *moveSpeed;

    }

    private void Update()
    {
        float attackvalue = inputAction.Ground.Attack.ReadValue<float>();
        if (attackvalue == 1)
        {
            Debug.Log("Attack 1");
        }

        if (inputAction.Ground.Attack.triggered)
        {
            Debug.Log("Attack 2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Equipt(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Equipt (1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Equipt(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Equipt(3);
        }
    }

    void FixedUpdate()
    {
        Movement();
    }

    public BodyPart GetBodyPart()
    {
        return BodyPart.Body;
    }
}

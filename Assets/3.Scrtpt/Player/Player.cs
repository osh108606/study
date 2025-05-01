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
    public Weapon curweapon;
    
    public WeaponSlot weaponslot = WeaponSlot.Main1;
    public Weapon[] weaponSlots = new Weapon[4];

    MainInputSystem inputAction;

    private void Awake()
    {
        inputAction = new MainInputSystem();
        

        Instance = this;
        Debug.Log("Awake");
        rb2d = GetComponent<Rigidbody2D>();
        weapons = GetComponentsInChildren<Weapon>(true);
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
        Equipment main1 = User.Instance.GetSetUpWeapon(WeaponSetUpType.Main1);
        Equipment main2 = User.Instance.GetSetUpWeapon(WeaponSetUpType.Main2);
        if (main1 == null&&main2 == null)
        {
            main1 = new Equipment();
            main2 = new Equipment();
            main1.key = WeaponType.AR.ToString();
            main1.setUpType = WeaponSetUpType.Main1;
            User.Instance.SetUp(WeaponSetUpType.Main1, main1);
            main2.key = WeaponType.SMG.ToString();
            main2.setUpType = WeaponSetUpType.Main2;
            User.Instance.SetUp(WeaponSetUpType.Main2, main2);
        }
        
        Equipt(main1.key);
        WeaponChange();
        Debug.Log("Start");
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            weaponslot = (WeaponSlot)(((int)weaponslot) + 1);
            if ((int)weaponslot > 3)
            {
                weaponslot = WeaponSlot.Main1;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            weaponslot = (WeaponSlot)(((int)weaponslot) - 1);
            if ((int)weaponslot < 0)
            {
                weaponslot = WeaponSlot.Special;
            }
        }
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
    public void Equipt(string weaponKey)//intÇü
    {

        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].weaponInfo.weaponType.ToString() == weaponKey)
            {
                curweapon = weapons[i];
                weapons[i].gameObject.SetActive(true);
            }
            else
            {
                weapons[i].gameObject.SetActive(false);
            }
        }
        
    }
    public void WeaponChange()//intÇü
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].weaponInfo.weaponUse == WeaponUseType.Main)
            {
                for (int j = 0; j < 2; j++)
                {
                    if(weaponSlots[j] = null)
                    {
                        weaponSlots[j] = weapons[i];
                    }
                }
            }
            else if (weapons[i].weaponInfo.weaponUse == WeaponUseType.Sub)
            {
                if (weaponSlots[2] == null)
                {
                    weaponSlots[2] = weapons[i];
                }
            }
            else if(weapons[i].weaponInfo.weaponUse == WeaponUseType.special)
            {
                if (weaponSlots[3] == null)
                {
                    weaponSlots[3] = weapons[i];
                }
            }
        }


    }
    void Movement()
    { 
        Vector2 moveVec = inputAction.Ground.Move.ReadValue<Vector2>();
        rb2d.linearVelocity = moveVec.normalized *moveSpeed;

    }

    //private void Update()
    //{
    //    //float attackvalue = inputAction.Ground.Attack.ReadValue<float>();
        
        
    //}

    void FixedUpdate()
    {
        Movement();
    }

    public BodyPart GetBodyPart()
    {
        return BodyPart.Body;
    }
    public enum WeaponSlot
    {
        Main1 = 0,
        Main2,
        Sub,
        Special
    }
}

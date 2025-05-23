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
    
    public WeaponSlotType weaponslot = WeaponSlotType.Main1;
    public Weapon[] weaponSlots = new Weapon[4];
    public WeaponStatusPanel weaponStatusPanel;
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
        
        Equipt(User.Instance.GetSetUpWeapon(WeaponSlotType.Main1).key);
        WeaponChange();
        Debug.Log("Start");
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            weaponslot = (WeaponSlotType)(((int)weaponslot) + 1);
            if ((int)weaponslot > 3)
            {
                weaponslot = WeaponSlotType.Main1;
            }
            ChangeSlot();
        }
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            weaponslot = (WeaponSlotType)(((int)weaponslot) - 1);
            if ((int)weaponslot < 0)
            {
                weaponslot = WeaponSlotType.Special;
            }
            ChangeSlot();
        }
    }
    public void ChangeSlot()
    {
        Equipment equipment = User.Instance.GetSetUpWeapon(weaponslot);
        if (equipment != null)
            Equipt(equipment.key);
        else
            curweapon = null;
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
        curweapon = null;
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
        weaponStatusPanel.Equiped();
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
    
}
public enum WeaponSlotType
{
        Main1 = 0,
        Main2,
        Sub,
        Special,
        Count,
        None
}
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

// Weapon 클래스는 MonoBehaviour를 상속받아 Unity의 게임 오브젝트로 동작합니다.
public class Weapon : MonoBehaviour
{

    // 무기 기본 정보를 담은 변수
    public WeaponInfo weaponInfo;
    // 발사할 총알 프리팹 (미리 만들어진 총알 템플릿)
    public Bullet bulletPrefab;
    //무기 바리에이션 용 무기 능력치
    public float accuracyMultiy=1;
    public float stabilityMultiy=1;
    public int exCilpammo=0;
    // 발사 간격 조절용 시간 변수
    public float time = 1f;
    
    // 무기에 장착된 부품 배열
    public WeaponPart[] weaponParts;

    private bool isReloading = false;
    private float reloadTimer = 0f;

    [SerializeField]
    WeaponSlotType slotType;

    // 총알 오브젝트 풀링에 사용할 리스트 (활성화된 총알들을 관리할 의도로 보임)
    List<Bullet> crurrentBullets = new List<Bullet>();
    // 오브젝트 풀링용 총알 리스트 (비활성화된 총알 포함)
    List<Bullet> bullets = new List<Bullet>();

    // 무기의 최종 데미지를 계산하는 함수
    public float GetDamage()
    {
        float weaponPartDamage = 0;
        // 무기에 장착된 각 부품들의 추가 데미지를 누적
        for (int i = 0; i < weaponParts.Length; i++)
        {
            if (weaponParts[i] == null)
                continue;
            weaponPartDamage += weaponParts[i].damage;
        }
        // 기본 데미지와 부품 추가 데미지를 합산하여 반환
        return weaponInfo.baseDamage + weaponPartDamage;
    }

    // 무기의 최종 명중률(정확도)을 계산하는 함수
    public float GetAccuracy()
    {
        float weaponPartAccuracy = 0;
        // 각 부품들이 제공하는 명중률 보정치를 누적 (음수 값을 빼서 적용)
        for (int i = 0; i < weaponParts.Length; i++)
        {
            if (weaponParts[i] == null)
                continue;
            weaponPartAccuracy -= weaponParts[i].accuracy;
        }
        // 기본 명중률에서 부품 보정치를 적용하여 최종 명중률 계산
        return accuracyMultiy * weaponInfo.accuracy - weaponPartAccuracy;
    }

    // 무기의 최종 안정성(반동)을 계산하는 함수
    public float GetStability()
    {
        float weaponPartStability = 0;
        // 각 부품들이 제공하는 안정성 보정치를 누적 (음수 값을 빼서 적용)
        for (int i = 0; i < weaponParts.Length; i++)
        {
            if (weaponParts[i] == null)
                continue;
            weaponPartStability -= weaponParts[i].stability;
        }
        // 기본 안정성에서 부품 보정치를 적용하여 최종 안정성 계산
        return stabilityMultiy * weaponInfo.stability - weaponPartStability;
    }

    // 무기의 최종 안정성(반동)을 계산하는 함수
    public float Getcilpammo()
    {
        float weaponPartCilpammo = 0;
        // 각 부품들이 제공하는 안정성 보정치를 누적 (음수 값을 빼서 적용)
        for (int i = 0; i < weaponParts.Length; i++)
        {
            if (weaponParts[i] == null)
                continue;
            weaponPartCilpammo -= weaponParts[i].cilpammo;
        }
        // 기본 안정성에서 부품 보정치를 적용하여 최종 안정성 계산
        return (exCilpammo + weaponInfo.cilpammo) - weaponPartCilpammo;
    }
    /* 
       무기 타입별 특성에 관한 주석
       HG  : 보통 반동, 보통 명중률, 초탄(최소 1 ~ 최대 5발) 변동 없음
       SMG : 낮은 반동, 낮은 명중률, 초탄(최소 1 ~ 최대 5발)에 명중률 변동
       AR  : 높은 명중률, 보통 반동, 초탄(최소 1 ~ 최대 5발)에 반동 변동
       MG  : 낮은 시작 명중률, 시작 반동, 발사 시 명중률과 반동이 증가
    */

    // 초기화, 무기가 시작될 때 호출
    public virtual void Start()
    {
        
    }

    // 매 프레임마다 업데이트
    public virtual void Update()
    {
        // 분당 발사 속도(RPM)를 초당 발사 속도로 변환
        float FPS = weaponInfo.RPM / 60;
        // 발사 간격 (1초를 FPS로 나눈 값)
        float fireRate = 1f / FPS;
        // 경과 시간 누적
        time += Time.deltaTime;

        int currentSlotIndex = (int)User.Instance.userData.currentSlot;
        int[] ammoArray = User.Instance.userData.currentAmmoSlot;
        
        // 발사 가능 조건
        bool canFire = time >= fireRate && ammoArray[currentSlotIndex] > 0;

        // 자동 비자동 조건
        bool isFirePressed = weaponInfo.automaticFire ? Input.GetMouseButton(0) : Input.GetMouseButtonDown(0);



        if (isReloading)
        {
            reloadTimer -= Time.deltaTime;

            if (reloadTimer <= 0f)
            {
                
                int current = ammoArray[currentSlotIndex];
                
                int max = weaponInfo.cilpammo;

                int reload = max - current;

                //체크x
                Ammo ammo = User.Instance.GetUesrAmmo(weaponInfo.ammoType);

                // 탄창 충전
                ammoArray[currentSlotIndex] += reload;
                // 인벤토리 탄약 차감
                ammo.count -= reload;
                isReloading = false;
            }
            
            return; // 장전 중엔 발사, 재장전, 입력 등 모두 차단
        }

        // 재장전: R키를 눌렀을 때 현재 탄약이 최대 탄약보다 적으면 재장전 수행
        if (Input.GetKeyDown(KeyCode.R) && (ammoArray[currentSlotIndex] < weaponInfo.cilpammo))
        {
            Reload();
        }

        if (!canFire)
        {
            return;
        }
            
        if (isFirePressed)
        {
            if (weaponInfo.weaponType == WeaponType.SG)
            {
                SGShoot();
            }
            else
            {
                Shoot();
            }

            time = 0f;
            ammoArray[currentSlotIndex]--;
        }
    }

    // 일반 발사 메서드: 총알을 하나 발사합니다.
    public virtual void Shoot()
    {
        // 마우스의 스크린 좌표를 가져옴
        Vector2 screenPoint = Input.mousePosition;
        // 스크린 좌표를 월드 좌표로 변환 (총의 위치와 비교하기 위함)
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
        // 총알이 날아갈 방향 계산 (월드 좌표 기준)
        Vector2 directtion = worldPoint - (Vector2)transform.position;

        // 오브젝트 풀링을 사용하여 총알을 가져옴 (활성화된 총알이 없으면 새로 생성)
        Bullet bullet = GetbulletInPool();
        // 총알의 위치를 무기의 위치로 설정
        bullet.gameObject.transform.position = transform.position;
        // 총알을 지정된 방향으로 발사 (정규화된 방향 벡터 사용)
        bullet.Shoot(this, directtion.normalized);
    }

    // 산탄총 발사 메서드: 한 번에 여러 개의 총알을 발사합니다.
    public void SGShoot()
    {
        // 마우스의 스크린 좌표를 가져옴
        Vector2 screenPoint = Input.mousePosition;
        // 스크린 좌표를 월드 좌표로 변환
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);

        // 기본 발사 방향 계산 (정규화된 방향 벡터)
        Vector2 direction = (worldPoint - (Vector2)transform.position).normalized;

        // 8발의 산탄을 발사하면서 각 총알에 약간의 랜덤 각도(±5도) 적용
        for (int i = 0; i < 8; i++)
        {
            // -5도부터 5도 사이의 랜덤 회전값 생성
            Quaternion rotation1 = Quaternion.Euler(0, 0, Random.Range(5f, -5f));
            // 랜덤 회전값을 적용한 새로운 발사 방향 계산
            Vector3 dir1 = rotation1 * direction;
            // 개별 산탄 발사 메서드 호출
            SGShoot(dir1);
        }
    }

    // 산탄총 개별 총알 발사 메서드: 주어진 방향으로 총알을 발사합니다.
    void SGShoot(Vector2 dir)
    {
        // 총알 프리팹을 인스턴스화하여 새로운 총알 생성
        Bullet bullet2 = GetbulletInPoolShoot();
        // 생성된 총알의 위치를 무기의 위치로 설정
        bullet2.gameObject.transform.position = transform.position;
        // 총알을 주어진 방향으로 발사
        bullet2.Shoot(this, dir);
    }

    // 총알 오브젝트 풀링 메서드: 비활성화된 총알을 반환하거나, 없으면 새로 생성
    public Bullet GetbulletInPool()
    {
        // 리스트에 있는 총알들을 순회하며
        for (int i = 0; i < bullets.Count; i++)
        {
            // 이미 활성화된 총알은 건너뜀
            if (bullets[i].gameObject.activeSelf)
            {
                continue;
            }
            // 비활성화된 총알을 활성화시키고 반환
            bullets[i].gameObject.SetActive(true);
            return bullets[i];
        }
        // 사용 가능한 총알이 없다면, 새로 생성하여 리스트에 추가 후 반환
        Bullet bullet = Instantiate(bulletPrefab);
        bullets.Add(bullet);
        return bullet;
    }

    public Bullet GetbulletInPoolShoot()
    {
        // 리스트에 있는 총알들을 순회하며
        for (int i = 0; i < bullets.Count; i++)
        {
            // 이미 활성화된 총알은 건너뜀
            if (bullets[i].gameObject.activeSelf)
            {
                continue;
            }
            // 비활성화된 총알을 활성화시키고 반환
            bullets[i].gameObject.SetActive(true);
            return bullets[i];
        }
        // 사용 가능한 총알이 없다면, 새로 생성하여 리스트에 추가 후 반환
        Bullet bullet = Instantiate(bulletPrefab);
        bullets.Add(bullet);
        bullets.Add(bullet);
        bullets.Add(bullet);
        bullets.Add(bullet);
        bullets.Add(bullet);
        bullets.Add(bullet);
        bullets.Add(bullet);
        bullets.Add(bullet);
        return bullet;
    }

    // 재장전 메서드: 탄약을 최대치로 회복합니다.
    public void Reload()
    {
        
        Debug.Log("장전중");
        // 현재 탄약 수를 최대 탄약 수로 재설정
        if (isReloading) 
            return;

        isReloading = true;
        reloadTimer = weaponInfo.reloadSpeed;
        
        Debug.Log("장전완료");
    }

    public void ChangeSlot(WeaponSlotType weaponSlot)
    {
        slotType = weaponSlot;
    }

    // 적중 시 처리할 메서드 (하위 클래스에서 오버라이딩하여 사용)
    public virtual void Hittied(BodyPart bodyPart)
    {
        // 기본 구현은 없음
    }
}

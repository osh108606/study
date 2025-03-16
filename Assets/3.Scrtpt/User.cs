using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{

    public static User Instance;
    public UserData userData;
    public Equipment equipment;
    public bulletItem bulletItem;
    public string itemName;
    public int itemCount;
    
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        userData = SaveManager.LoadData<UserData>("UserData");
        //초기 유저 데이터
        if (userData == null)
        {
            userData = new UserData();
            userData.nickname = "player";
            //userData.gold = 100;
            //userData.weaponkey = "Pistol";
            SaveManager.SaveData("UserData", userData);
        }
    }

    private void Update()
    {
        //디버그용 코드
        if (Input.GetKeyDown(KeyCode.H))
        {
            UserItem userItem = new UserItem();
            userItem.key = itemName;
            userItem.count = itemCount;

            userData.userItems.Add(userItem);
        }
        else if(Input.GetKeyDown(KeyCode.J))
        {
            Equipment equipment = new Equipment();
            equipment.key = itemName;
            

            userData.equipments.Add(equipment);
        }
    }

    public void AddItem(string key, int count)
    {
        UserItem userItem = GetUesrItem(key);
        userItem.count += count;
        SaveManager.SaveData("UserData", userData);
    }
    public UserItem GetUesrItem(string key)
    {
        for (int i = 0; i < userData.userItems.Count; i++)
        {
            if (key == userData.userItems[i].key)
            {
                return userData.userItems[i];
            }
        }
        UserItem userItem = new UserItem();
        userItem.key = key;
        userItem.count = 0;

        userData.userItems.Add(userItem);
        return userItem;
    }
}


[System.Serializable]
public class UserData
{
    public string nickname;
    //public int gold;
    //public string weaponkey;
    public List<UserItem> userItems = new List<UserItem>();
    public List<Equipment> equipments = new List<Equipment>();
}

[System.Serializable]
public class UserItem
{
    public string key;
    public int count;
}
[System.Serializable]
public class Equipment
{
    public string key;

}
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{

    public static User Instance;
    public UserData userData;
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

        if (userData == null)
        {
            userData = new UserData();
            userData.nickname = "짱짱";
            userData.gold = 100;
            userData.weaponkey = "Pistol";
            SaveManager.SaveData("UserData", userData);
        }

        

        
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.H))
        {
            UserItem userItem = new UserItem();
            userItem.key = itemName;
            userItem.count = itemCount;

            userData.userItems.Add(userItem);
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
    public int gold;
    public string weaponkey;
    public List<UserItem> userItems = new List<UserItem>();
}

[System.Serializable]
public class UserItem
{
    public string key;
    public int count;

    
}
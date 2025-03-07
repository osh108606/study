//SaveFile() fName�� �����ϱ� + T Ÿ���� �����͸� ���� �̸�
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager
{
public static void SaveData<T>(string fName, T data)
{

#if UNITY_EDITOR
    string path = Path.Combine(Application.dataPath, fName);
#else
        string path = Path.Combine(Application.persistentDataPath, fName);
#endif
    Debug.Log($"������ �ε� ��� : {path}");
    if (!File.Exists(path))
    {
        File.Create(path).Close();
    }

    string ToJsonData = JsonUtility.ToJson(data, true);
    Debug.Log(ToJsonData);
    File.WriteAllText(path, ToJsonData);
}

// LoadFile ������ �ε��ϱ�
public static T LoadData<T>(string fName)
{
    T data = default;
#if UNITY_EDITOR //����Ƽ �����Ϳ����� ���۵Ǵ� �ڵ�
    string path = Path.Combine(Application.dataPath, fName);
#else
				//�����Ͱ� �ƴ� ��� 
        string path = Path.Combine(Application.persistentDataPath, fName);
#endif
    Debug.Log($"������ ���̺� ��� : {path}");

    if (File.Exists(path))
    {
        string FromJsonData = File.ReadAllText(path);
        data = JsonUtility.FromJson<T>(FromJsonData);
    }

    return data;
}


}
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// SaveManager Ŭ������ ���׸� Ÿ��(T)�� �����͸� JSON �������� �����ϰ� �ҷ����� ����� �����մϴ�.
public class SaveManager:MonoBehaviour
{
    // SaveData<T>() �޼���� fName�̶�� ���� �̸��� ����Ͽ� T Ÿ���� �����͸� �����մϴ�.
    public static void SaveData<T>(string fName, T data)
    {
        // UNITY_EDITOR ��ó�� ���ù�: ������ ȯ��� ����� ���ø����̼ǿ����� ���� ��θ� �ٸ��� �����մϴ�.
#if UNITY_EDITOR
        // Unity �����Ϳ����� ������Ʈ�� Assets ���� ��θ� �������� ������ �����մϴ�.
        string path = Path.Combine(Application.dataPath, fName);
#else
        // ����� ���ø����̼ǿ����� ������� persistentDataPath(������ ���� ���)�� ����մϴ�.
        string path = Path.Combine(Application.persistentDataPath, fName);
#endif
        Debug.Log($"������ �ε� ��� : {path}");

        // ������ ��ο� ������ �������� �ʴ� ��� ���� �����մϴ�.
        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }

        // �����͸� JSON ������ ���ڿ��� ��ȯ�մϴ�.
        // �� ��° ���ڸ� true�� �����Ͽ� �������� ���� ����(�鿩���� ����)���� ��ȯ�մϴ�.
        string ToJsonData = JsonUtility.ToJson(data, true);
        Debug.Log(ToJsonData);

        // ��ȯ�� JSON �����͸� ���Ͽ� ����Ͽ� �����մϴ�.
        File.WriteAllText(path, ToJsonData);
    }

    // LoadData<T>() �޼���� fName ���Ͽ��� JSON �����͸� �о�� T Ÿ���� �����ͷ� ��ȯ�Ͽ� ��ȯ�մϴ�.
    public static T LoadData<T>(string fName)
    {
        // ���׸� Ÿ�� T�� �⺻���� data ������ �ʱ�ȭ�մϴ�.
        T data = default;
#if UNITY_EDITOR
        // Unity �����Ϳ����� ������Ʈ�� Assets ���� ��θ� �������� ������ �ҷ��ɴϴ�.
        string path = Path.Combine(Application.dataPath, fName);
#else
        // ����� ���ø����̼ǿ����� ������� persistentDataPath�� ����մϴ�.
        string path = Path.Combine(Application.persistentDataPath, fName);
#endif
        Debug.Log($"������ ���̺� ��� : {path}");

        // ������ �����ϴ� ��쿡�� �����͸� �о�ɴϴ�.
        if (File.Exists(path))
        {
            // ������ ��� �ؽ�Ʈ�� �о�ɴϴ�.
            string FromJsonData = File.ReadAllText(path);
            // �о�� JSON �����͸� T Ÿ������ ��ȯ�մϴ�.
            data = JsonUtility.FromJson<T>(FromJsonData);
        }

        // ��ȯ�� �����͸� ��ȯ�մϴ�.
        // ������ ���� ��� �⺻��(default)�� ��ȯ�˴ϴ�.
        return data;
    }
}

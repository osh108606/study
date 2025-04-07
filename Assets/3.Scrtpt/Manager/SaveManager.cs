using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// SaveManager 클래스는 제네릭 타입(T)의 데이터를 JSON 형식으로 저장하고 불러오는 기능을 제공합니다.
public class SaveManager:MonoBehaviour
{
    // SaveData<T>() 메서드는 fName이라는 파일 이름을 사용하여 T 타입의 데이터를 저장합니다.
    public static void SaveData<T>(string fName, T data)
    {
        // UNITY_EDITOR 전처리 지시문: 에디터 환경과 빌드된 애플리케이션에서의 저장 경로를 다르게 지정합니다.
#if UNITY_EDITOR
        // Unity 에디터에서는 프로젝트의 Assets 폴더 경로를 기준으로 파일을 저장합니다.
        string path = Path.Combine(Application.dataPath, fName);
#else
        // 빌드된 애플리케이션에서는 사용자의 persistentDataPath(데이터 지속 경로)를 사용합니다.
        string path = Path.Combine(Application.persistentDataPath, fName);
#endif
        Debug.Log($"데이터 로드 경로 : {path}");

        // 지정된 경로에 파일이 존재하지 않는 경우 새로 생성합니다.
        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }

        // 데이터를 JSON 형식의 문자열로 변환합니다.
        // 두 번째 인자를 true로 전달하여 가독성이 높은 포맷(들여쓰기 포함)으로 변환합니다.
        string ToJsonData = JsonUtility.ToJson(data, true);
        Debug.Log(ToJsonData);

        // 변환된 JSON 데이터를 파일에 기록하여 저장합니다.
        File.WriteAllText(path, ToJsonData);
    }

    // LoadData<T>() 메서드는 fName 파일에서 JSON 데이터를 읽어와 T 타입의 데이터로 변환하여 반환합니다.
    public static T LoadData<T>(string fName)
    {
        // 제네릭 타입 T의 기본값을 data 변수에 초기화합니다.
        T data = default;
#if UNITY_EDITOR
        // Unity 에디터에서는 프로젝트의 Assets 폴더 경로를 기준으로 파일을 불러옵니다.
        string path = Path.Combine(Application.dataPath, fName);
#else
        // 빌드된 애플리케이션에서는 사용자의 persistentDataPath를 사용합니다.
        string path = Path.Combine(Application.persistentDataPath, fName);
#endif
        Debug.Log($"데이터 세이브 경로 : {path}");

        // 파일이 존재하는 경우에만 데이터를 읽어옵니다.
        if (File.Exists(path))
        {
            // 파일의 모든 텍스트를 읽어옵니다.
            string FromJsonData = File.ReadAllText(path);
            // 읽어온 JSON 데이터를 T 타입으로 변환합니다.
            data = JsonUtility.FromJson<T>(FromJsonData);
        }

        // 변환된 데이터를 반환합니다.
        // 파일이 없을 경우 기본값(default)이 반환됩니다.
        return data;
    }
}

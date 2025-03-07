using UnityEngine;
using UnityEngine.LightTransport;
public enum Difficulty
{
    VeryEasy,
    Easy,
    Normal,
    Hard,
    VeryHard,
    Hero,
    HeroPlus1,
    HeroPlus2,
    HeroPlus3,
    HeroPlus4,
    Legendary
}
public class DifficultyManager : MonoBehaviour
{
    public Difficulty worlddifficulty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        worlddifficulty = Difficulty.VeryEasy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [System.Serializable]
    public class DifficultyData
    {
        public int MinLevel;  // �ּ� ����
        public int MaxLevel;  // �ִ� ����
        public Difficulty worlddifficulty;
        public float XPModifier;  // ����ġ ���
    }

    public void difficultySpawn()
    {

    }
    public void diffocultydrop()
    {

    }
}

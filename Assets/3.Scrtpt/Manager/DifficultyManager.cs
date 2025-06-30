using UnityEngine;
using UnityEngine.LightTransport;
public enum Difficulty //난이도 목록
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
    public Difficulty worlddifficulty; //전체 난이도
    
    void Start()
    {
        worlddifficulty = Difficulty.VeryEasy; //초기 난이도
    }

    void Update()
    {
        
    }

    [System.Serializable]
    public class DifficultyData
    {
        public int MinLevel;  // 최소 레벨
        public int MaxLevel;  // 최대 레벨
        public Difficulty worldDifficulty;
        public float XPModifier;  // 경험치 배수
    }

    public void difficultySpawn()
    {

    }
    public void diffocultydrop()
    {

    }
}

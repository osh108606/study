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
        public int MinLevel;  // 최소 레벨
        public int MaxLevel;  // 최대 레벨
        public Difficulty worlddifficulty;
        public float XPModifier;  // 경험치 배수
    }

    public void difficultySpawn()
    {

    }
    public void diffocultydrop()
    {

    }
}

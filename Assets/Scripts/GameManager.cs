using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Text scoreText; // Attach score text here

    // Public property for score
    public int score { get; private set; } = 0;

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        SetScore(score); //shows candy score display
    }

    // this updates score ui
    public void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString().PadLeft(4, '0');
    }

    // updates score with "Candy Reward" in the wuest goal script
    public void UpdateCandyScore(QuestGoal questGoal)
    {
        if (questGoal != null)
        {
            SetScore(score + questGoal.candyReward);
        }
        else
        {
            Debug.LogWarning("QuestGoal is null in UpdateCandyScore!");
        }
    }
}
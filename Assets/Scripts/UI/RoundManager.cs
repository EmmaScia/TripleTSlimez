using System.Collections;
using UnityEngine;
using TMPro;

public class RoundManager : MonoBehaviour
{
    public static RoundManager Instance { get; private set; }

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private TMP_Text displayText;
    [SerializeField] private float timeBetweenRounds = 10f;
    [SerializeField] private float timeBetweenSpawns = 0.8f;

    private readonly int[] enemiesPerRound = { 3, 5, 8 };
    private int currentRound = 0;
    private int enemiesAlive = 0;
    private bool allEnemiesSpawned = false;
    private bool isInRound = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(StartRound());
    }

    private IEnumerator StartRound()
    {
        currentRound++;
        enemiesAlive = 0;
        allEnemiesSpawned = false;
        isInRound = true;

        UpdateDisplay($"Round {currentRound}");
        yield return new WaitForSeconds(2f);

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        int count = enemiesPerRound[currentRound - 1];
        for (int i = 0; i < count; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
        allEnemiesSpawned = true;
        CheckRoundEnd();
    }

    private void SpawnEnemy()
    {
        if (spawnPoints.Length == 0 || enemyPrefab == null) return;
        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemyPrefab, point.position, point.rotation);
        enemiesAlive++;
    }

    public void OnEnemyDied()
    {
        if (!isInRound) return;

        enemiesAlive--;

        if (GameManager.Instance != null)
            GameManager.Instance.AddKill();

        CheckRoundEnd();
    }

    private void CheckRoundEnd()
    {
        if (!isInRound || !allEnemiesSpawned || enemiesAlive > 0) return;

        isInRound = false;

        if (currentRound >= enemiesPerRound.Length)
        {
            UpdateDisplay("You Win!");
            StartCoroutine(LoadEndScreen(3f));
        }
        else
        {
            StartCoroutine(Countdown());
        }
    }

    private IEnumerator Countdown()
    {
        float timer = timeBetweenRounds;
        while (timer > 0f)
        {
            UpdateDisplay($"Next Round in: {Mathf.CeilToInt(timer)}");
            yield return new WaitForSeconds(1f);
            timer -= 1f;
        }
        StartCoroutine(StartRound());
    }

    private IEnumerator LoadEndScreen(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (GameManager.Instance != null)
            GameManager.Instance.GameOver();
        else
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndScreen");
    }

    private void UpdateDisplay(string message)
    {
        if (displayText != null)
            displayText.text = message;
    }
}

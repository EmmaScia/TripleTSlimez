using UnityEngine;
using UnityEngine.UI; // Required for Image references

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public Image[] hearts; // Drag your 3 Heart Images here in the Inspector
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject gameOverPanel;

    public void TakeDamage(int amount)
    {
        health -= amount;
        UpdateHeartsUI();

        if (health <= 0)
        {
            Die();
        }
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // If the current heart index is less than health, show full; otherwise, empty
            hearts[i].sprite = (i < health) ? fullHeart : emptyHeart;
        }
    }

    void Die()
    {
        gameOverPanel.SetActive(true); // Show the Game Over screen
        Time.timeScale = 0; // Freeze the game
        Destroy(gameObject); // Optional: remove player character
    }
}

using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;       // Current health
    public int numOfHearts = 3; // Maximum hearts

    public Image[] hearts;       // Array to hold the heart UI images
    public Sprite fullHeart;    // Sprite for a full heart
    public Sprite emptyHeart;   // Sprite for an empty heart

    void Update()
    {
        // Loop through each heart image and update its sprite
        for (int i = 0; i < hearts.Length; i++)
        {
            // If the heart index is less than current health, show it as full
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            // Optional: Hide hearts that exceed the maximum capacity
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, numOfHearts); // Keep health within 0-3
    }
}

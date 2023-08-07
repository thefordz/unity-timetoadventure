using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] Text coinText;                     // Currency indicator.
    [SerializeField] Image healthImage;                 // Health bar.
    [SerializeField] HealthController adventurerHealth; // Reference to the health of the character.

    private int coins = 0;                              // Amount of coins collected.


    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        // Restart the scene when you press.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddHealth(int health)
    {
        // We convert health into a number between 0 and 1.
        float h = (float)health / adventurerHealth.vitality;

        // We updated the life bar.
        healthImage.fillAmount = h;
    }

    public void AddCoins(int amount)
    {
        // We add the amount of coins.
        coins += amount;

        // We update the currency indicator.
        coinText.text = coins.ToString();
    }

    private void OnEnable()
    {
        // We subscribe to the health delegate.
        adventurerHealth.HealthEvent += AddHealth;
    }

    private void OnDisable()
    {
        // We unsubscribe to the health delegate.
        adventurerHealth.HealthEvent -= AddHealth;
    }
}

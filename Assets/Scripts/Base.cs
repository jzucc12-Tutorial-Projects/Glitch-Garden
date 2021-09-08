using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    [SerializeField] int baseHealth = 3;
    Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        SetLives();
        healthText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        healthText.text = baseHealth.ToString();
    }

    public void TakeBaseDamage()
    {
        baseHealth--;
        UpdateDisplay();
        if(baseHealth <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        FindObjectOfType<SceneLoader>().GameOver();
        Time.timeScale = 0;
    }

    private void SetLives()
    {
        baseHealth = 10 - Mathf.RoundToInt(PlayerPrefsController.GetDifficulty());
    }
}

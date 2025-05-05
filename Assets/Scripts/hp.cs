using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hp : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public float health;
    public int damage = 1;

    public healthbar healthbar;
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            TakeDamage(1);
        }

        if (currentHealth <= 0)
            GameOver();
    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);
    }

    

    private void GameOver()
    {
        SceneManager.LoadScene(3);
    }
}

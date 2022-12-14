using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public RectTransform healthbar;

    [SerializeField]
    GameObject getstatus;


    public void TakeDamage(int amount)
    {
        bool blocking = getstatus.GetComponent<Caracter2>().vulnerable;
        if (blocking && PlayerHandler.gameStart)
        {
            currentHealth -= amount;
        }
        if(currentHealth <=0)
        {
            currentHealth = 0;
            Debug.Log("Dead");
            PlayerHandler.PlayerCount--;
            if(PlayerHandler.PlayerCount <2)
            {
                PlayerHandler.gameStart = false;
                PlayerHandler.PlayerCount = 0;
                SceneManager.LoadScene(5);
            }
            

        }

        healthbar.sizeDelta = new Vector2(currentHealth * 2, healthbar.sizeDelta.y);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P1Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    //void Damage()
    //I'll add this when we get attacks made
    void OnBecameInvisible()
    {
        currentHealth = 0;
        SceneManager.LoadScene(5);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8f, 8f),
        Mathf.Clamp(transform.position.y, -10f, 4f), transform.position.z);
    }
}

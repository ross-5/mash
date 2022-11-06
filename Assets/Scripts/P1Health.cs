using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
    // Update is called once per frame
    void Update()
    {
     
    }
}

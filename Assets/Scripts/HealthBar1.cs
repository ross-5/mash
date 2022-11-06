using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar1 : MonoBehaviour
{
    public P1Health p1health;
    public Image fillimage;
    private Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float fillvalue = p1health.currentHealth / p1health.maxHealth;
        slider.value = fillvalue;
    }
}

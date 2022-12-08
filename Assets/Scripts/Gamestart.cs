using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gamestart : MonoBehaviour
{
    float seconds = 10;
    [SerializeField]
    GameObject timer;
    [SerializeField]
    GameObject Spawner;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timercountdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Timercountdown()
    {
        while (seconds > 0f)
        {
        yield return new WaitForSeconds(1f);
        seconds--;
        timer.GetComponent<TextMeshProUGUI>().SetText(seconds.ToString());
        }
        Spawner.SetActive(false);
        timer.SetActive(false);
        PlayerHandler.gameStart = true;
    }
}

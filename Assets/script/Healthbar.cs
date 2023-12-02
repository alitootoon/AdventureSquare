using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Healthbar : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    private TextMeshProUGUI healthbarTemp;
    // Start is called before the first frame update
    private void Awake()
    {
        health = maxHealth;
        healthbarTemp = GetComponent<TextMeshProUGUI>();
        healthbarTemp.text = "HP: " + health;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage(int amount)
    {
        health -= amount;
        healthbarTemp.text = "HP: " + health;

        if (health <= 0)
        {
            //die
        }
    }
}

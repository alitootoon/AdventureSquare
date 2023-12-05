using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public int maxHealth = 10;
    private TextMeshProUGUI healthbarTemp;
    public GameObject Player;
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

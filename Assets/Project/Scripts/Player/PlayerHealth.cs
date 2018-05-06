using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : Singleton<PlayerHealth> {
    [SerializeField]
    int PlayerLife = 100;
    [SerializeField]
    TextMeshProUGUI LifeField;

    public void DealDamage(int damage)
    {
        PlayerLife -= damage;
    }

    private void Update()
    {
        LifeField.text = "Life " + PlayerLife;
    }
}

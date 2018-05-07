using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : Singleton<PlayerHealth> {
    [SerializeField]
    int PlayerLife = 100;
    [SerializeField]
    TextMeshProUGUI LifeField;

    public void DealDamage(int damage)
    {
        PlayerLife -= damage;
        if(PlayerLife <= 0)
        {
            SceneManager.LoadScene("scn_LoseScreen");
        }
    }

    private void Update()
    {
        LifeField.text = "Life " + PlayerLife;
    }
}

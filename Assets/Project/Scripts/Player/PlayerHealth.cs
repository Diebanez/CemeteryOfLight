using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Singleton<PlayerHealth> {
    [SerializeField]
    int PlayerLife = 100;

    public void DealDamage(int damage)
    {
        PlayerLife -= damage;
    }
}

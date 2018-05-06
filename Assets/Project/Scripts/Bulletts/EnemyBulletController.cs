using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : BullettController
{

    [SerializeField]
    public int Damage = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerHealth.instance.DealDamage(Damage);
            Destroy(this.gameObject);
        }
    }
}

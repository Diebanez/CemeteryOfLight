using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowController : BullettController {
    [SerializeField]
    int lightDamage = 30;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerLight.instance.ReduceByOneLevel(lightDamage);
            Destroy(this.gameObject);
        }
    }
}

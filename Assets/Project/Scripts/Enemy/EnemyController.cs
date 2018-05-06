using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [SerializeField]
    float MovementSpeed;
    [SerializeField]
    float Damage;

    float ActualMovementSpeed;
    float ActualDamage;
    List<LightController> LightInRange = new List<LightController>();

    private void Start()
    {
        ActualMovementSpeed = MovementSpeed;
        ActualDamage = Damage;
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Light"))
        {
            if (!LightInRange.Contains(collision.gameObject.GetComponentInParent<LightController>())) {
                LightInRange.Add(collision.gameObject.GetComponentInParent<LightController>());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Light"))
        {
            if (LightInRange.Contains(collision.gameObject.GetComponentInParent<LightController>()))
            {
                LightInRange.Add(collision.gameObject.GetComponentInParent<LightController>());
            }
        }
    }
}

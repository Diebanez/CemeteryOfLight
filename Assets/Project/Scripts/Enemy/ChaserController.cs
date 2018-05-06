using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserController : EnemyController {
    [SerializeField]
    float AttackDistance = 1.0f;
    [SerializeField]
    float EngageDistance = 3.0f;  

    protected override void Update()
    {
        base.Update();
        if(Vector2.Distance(transform.position, PlayerHealth.instance.transform.position) <= AttackDistance)
        {
            PlayerHealth.instance.DealDamage((int)this.ActualDamage);
        }else if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y + 1.6f), new Vector2(PlayerHealth.instance.transform.position.x, PlayerHealth.instance.transform.position.y + 1.7f)) <= EngageDistance)
        {
            transform.Translate((new Vector3(PlayerHealth.instance.transform.position.x, PlayerHealth.instance.transform.position.y + 1.7f, 0.0f) - new Vector3(transform.position.x, transform.position.y + 1.6f, 0.0f)) * ActualMovementSpeed * Time.deltaTime);
        }
        else
        {
            this.ExecutePatternMovement();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y + 1.6f), EngageDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y + 1.6f), AttackDistance);
    }
}

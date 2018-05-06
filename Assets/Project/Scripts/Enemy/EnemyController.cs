using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [SerializeField]
    float MovementSpeed;
    [SerializeField]
    float Damage;
    [SerializeField]
    int Life = 10;
    [SerializeField]
    int PlayerDamage = 1;

    protected float ActualMovementSpeed;
    protected float ActualDamage;
    List<LightController> LightInRange = new List<LightController>();

    protected virtual void Start()
    {
        ActualMovementSpeed = MovementSpeed;
        ActualDamage = Damage;
    }

    protected virtual void Update()
    {
        if(LightInRange.Count > 0)
        {
            int LightLevel = 1;
            foreach(LightController lc in LightInRange)
            {
                if(lc.Ranges.LightLevel > LightLevel)
                {
                    LightLevel = lc.Ranges.LightLevel;
                }
            }
            switch (LightLevel)
            {
                case 1:
                    {
                        ActualMovementSpeed = MovementSpeed * .8f;
                        ActualDamage = Damage * .8f;
                        break;
                    }
                case 2:
                    {
                        ActualMovementSpeed = MovementSpeed * .6f;
                        ActualDamage = Damage * .6f;
                        break;
                    }
                case 3:
                    {
                        ActualMovementSpeed = MovementSpeed * .4f;
                        ActualDamage = Damage * .4f;
                        break;
                    }
            }
        }
        else
        {
            ActualMovementSpeed = MovementSpeed;
            ActualDamage = Damage;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Light"))
        {
            if (!LightInRange.Contains(collision.gameObject.GetComponentInParent<LightController>())) {
                LightInRange.Add(collision.gameObject.GetComponentInParent<LightController>());
            }
        }
        else if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            this.Life -= PlayerDamage;
            if( Life<= 0 )
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Light"))
        {
            if (LightInRange.Contains(collision.gameObject.GetComponentInParent<LightController>()))
            {
                LightInRange.Remove(collision.gameObject.GetComponentInParent<LightController>());
            }
        }
    }
}

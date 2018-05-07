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
    [SerializeField]
    Vector2[] PatternNodes;
    int PatternIndex = 0;

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

    protected void ExecutePatternMovement()
    {
        if ((int)transform.position.x == (int)PatternNodes[PatternIndex].x && (int)transform.position.y == (int)PatternNodes[PatternIndex].y)
        {
            if (PatternIndex < PatternNodes.Length - 1)
            {
                PatternIndex++;
            }
            else
            {
                PatternIndex = 0;
            }
        }
        if (PatternNodes.Length > 1)
        {
            Vector3 Movement = new Vector3(PatternNodes[PatternIndex].x, PatternNodes[PatternIndex].y, 0) - transform.position;
            transform.Translate((Movement / Movement.magnitude) * ActualMovementSpeed * Time.deltaTime);
        }
    }

    private void OnValidate()
    {
        if(PatternNodes.Length > 0)
        transform.position = new Vector3(PatternNodes[0].x, PatternNodes[0].y, transform.position.z);
    }
}

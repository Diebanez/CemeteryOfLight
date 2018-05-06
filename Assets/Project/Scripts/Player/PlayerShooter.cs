using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {
    [SerializeField]
    GameObject Bullet;
    [SerializeField]
    float ShootDelay = 0.20f;
    [SerializeField]
    GameObject Muzzle;

    float timer = 0;

    private void Start()
    {
        InputHandler.instance.Shoot += OnShoot;
        Muzzle.transform.parent = this.transform;
        Muzzle.transform.localPosition = Vector3.zero;
        timer = ShootDelay;
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnDestroy()
    {
        InputHandler.instance.Shoot -= OnShoot;
    }

    void OnShoot(Vector3 target)
    {
        if (timer >= ShootDelay)
        {
            timer = 0;
            Vector3 LookTarget = new Vector3(target.x, target.y, transform.position.z);
            Muzzle.transform.LookAt(LookTarget);
            Instantiate(Bullet, Muzzle.transform.position, Muzzle.transform.rotation);
        }
    }
}

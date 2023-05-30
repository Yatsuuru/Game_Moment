using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform shotPrefab;
    public float shootinRate = 0.25f;
    public float shootCooldown;

    private void Start()
    {
        shootCooldown = 0f;
    }
    private void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootinRate;
            var shotTransform = Instantiate(shotPrefab) as Transform;
            shotTransform.position = transform.position;

            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if(shot != null)
            {
                shot.isEnemyShoot = isEnemy;
            }
            MoveScript move = shotTransform.gameObject.GetComponentInChildren<MoveScript>();
            if(move != null)
            {
                move.direction = this.transform.right;
            }
        }
    }

    public bool CanAttack
    {
         get
        {
            return shootCooldown <= 0f;
        }
    }
}

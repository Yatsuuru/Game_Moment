using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public int damage = 1;
    public bool isEnemyShoot = false;

    private void Start()
    {
        Destroy(gameObject, 20);
    }
}

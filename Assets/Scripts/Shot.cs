using UnityEngine;

public class Shot : MonoBehaviour
{
    public int damage = 1;
    public bool isEnemyShot = false;

    void Start()
    {
        Destroy(gameObject, 2f);
    }
}

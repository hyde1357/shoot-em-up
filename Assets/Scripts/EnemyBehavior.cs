using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Weapon[] weapons;
    // Start is called before the first frame update
    void Awake()
    {
        weapons = GetComponentsInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Weapon weapon in weapons)
        {
            if (weapon != null && weapon.CanAttack)
            {
                weapon.Attack(true);
            }
        }
    }
}

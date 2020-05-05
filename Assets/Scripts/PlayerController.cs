using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector2 speed = new Vector2(7f, 7f);

    void Update()
    {
        MoveShip();

        //bool shoot = Input.GetButtonDown(KeyCode.Space);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Weapon weapon = GetComponent<Weapon>();
            if (weapon != null)
            {
                weapon.Attack(false);
            }
        }
    }

    private void MoveShip()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }
}

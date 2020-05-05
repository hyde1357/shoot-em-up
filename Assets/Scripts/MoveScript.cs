using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [SerializeField] Vector2 speed = new Vector2(2f, 2f);
    public Vector2 direction = new Vector2(-1, 0);

    void Update()
    {
        Vector3 movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);

        if(transform.position.x >= 4.1)
        {
            direction.x = -1;
        }
        else if(transform.position.x <= -4.1)
        {
            direction.x = 1;
        }
    }
}

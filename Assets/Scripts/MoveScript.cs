using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [SerializeField] Vector2 speed = new Vector2(2f, 2f);
    public Vector2 direction = new Vector2(-1, 0);
    [SerializeField] float period = 2f;
    [SerializeField] float radius = 2f;
    [SerializeField] float rotateSpeed = 2f;
    Vector2 startingPos;
    float movementFactor;
    const float tau = Mathf.PI * 2f;

    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        // Movement pattern is specified by tag value
        if(gameObject.tag == "SinEnemy")
        {
            float cycles = Time.time / period;

            float rawSinWave = Mathf.Sin(cycles * tau);
            movementFactor = rawSinWave * 2;
            Vector3 movement = new Vector3(speed.x * direction.x, speed.y * direction.y + movementFactor, 0);
            movement *= Time.deltaTime;
            MoveShip(movement);
        }
        else if (gameObject.tag == "CircleEnemy")
        {
            period += rotateSpeed * Time.deltaTime;

            var offset = new Vector2(Mathf.Sin(period), Mathf.Cos(period)) * radius;
            transform.position = startingPos + offset;
        }
        else
        {
            Vector3 movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);
            movement *= Time.deltaTime;
            MoveShip(movement);
        }

    }

    private void MoveShip(Vector3 movement)
    {
        transform.Translate(movement);

        if (transform.position.x >= 4.1)
        {
            direction.x = -1;
        }
        else if (transform.position.x <= -4.1)
        {
            direction.x = 1;
        }
    }
}

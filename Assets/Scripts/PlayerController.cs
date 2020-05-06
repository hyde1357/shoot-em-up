using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector2 speed = new Vector2(7f, 7f);
    [SerializeField] AudioClip gunSound;

    private Collider2D coliderComponent;

    void Start()
    {
        coliderComponent = GetComponent<Collider2D>();
    }

    void Update()
    {
        MoveShip();
        Shoot();
        RestrictPlayerMovement();

        if(Debug.isDebugBuild)
        {
            RespondToDebugKeys();
        }
    }
    private void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            coliderComponent.enabled = !coliderComponent.enabled;
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Weapon weapon = GetComponent<Weapon>();
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            if (weapon != null)
            {
                audioSource.PlayOneShot(gunSound);
                weapon.Attack(false);
            }
        }
    }

    private void MoveShip()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        //if(transform.position.x <= 4.1 && transform.position.x >= -4.1) { }
        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }

    private void RestrictPlayerMovement()
    {

        // Make sure we are not outside the camera bounds
        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(1, 0, dist)
        ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0.5f, dist)
        ).y;

        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
          Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
          transform.position.z
        );
    }
}

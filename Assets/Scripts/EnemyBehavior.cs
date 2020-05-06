using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Weapon[] weapons;
    private MoveScript moveScript;
    private Collider2D coliderComponent;
    private SpriteRenderer rendererComponent;
    public string testi = "Spawned enemy ship";

    public bool hasSpawn;
    [SerializeField] AudioClip gunSound;

    // Start is called before the first frame update
    void Awake()
    {
        weapons = GetComponentsInChildren<Weapon>();
        moveScript = GetComponent<MoveScript>();
        coliderComponent = GetComponent<Collider2D>();
        rendererComponent = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        hasSpawn = false;
        // Disable everything
        gameObject.SetActive(false);
    }

    void Update()
    {
        AutoFire();
    }
    
    public void Spawn()
    {
        hasSpawn = true;

        // Enable everything
        gameObject.SetActive(true);
    }

    private void AutoFire()
    {
        // Auto fire the gun
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        foreach (Weapon weapon in weapons)
        {
            if (weapon != null && weapon.enabled && weapon.CanAttack)
            {
                weapon.Attack(true);
                audioSource.PlayOneShot(gunSound);
            }
        }
    }

}

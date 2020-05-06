using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] int hp = 1;
    [SerializeField] bool isEnemy = true;
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] AudioClip hitSound;
    [SerializeField] private HealthBar healthBar;

    private Collider2D coliderComponent ;
    private SpriteRenderer rendererComponent;

    void Awake()
    {
        coliderComponent = GetComponent<Collider2D>();
        rendererComponent = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        Shot shot = collision.gameObject.GetComponent<Shot>();
        if(shot != null)
        {
            if(shot.isEnemyShot != isEnemy)
            {
                hp -= shot.damage;
                if(healthBar != null)
                {
                    float health = 0.05f * (float)hp;
                    healthBar.SetSize(health);
                }
                audioSource.PlayOneShot(hitSound);
                Destroy(shot.gameObject);
                if(hp <= 0)
                {
                    // Restart and disable everything if the destroyed object was player, destroy gameobject if not
                    if (gameObject.tag == "Player")
                    {
                        PlayExplosionInstance(gameObject.GetComponent<Transform>().position);
                        coliderComponent.enabled = false;
                        rendererComponent.enabled = false;
                        Invoke("ReloadLevel", 3f);
                    }
                    else
                    {
                        DestroyShip(gameObject.GetComponent<Transform>().position);
                    }
                }
            }
        }
    }
    private void DestroyShip(Vector3 position)
    {
        PlayExplosionInstance(position);
        Destroy(gameObject);
    }

    // Instansiate explosion particle effects and sounds to play stuff after destroying game object
    // TODO explosion effects on destroyed enemies do not get deleted
    private void PlayExplosionInstance(Vector3 position)
    {
        ParticleSystem explosionEffect = Instantiate(explosionParticles, position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(explosionSound, position);
        explosionEffect.Play();
        Destroy(explosionEffect, 1f);
    }

    // Restart
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

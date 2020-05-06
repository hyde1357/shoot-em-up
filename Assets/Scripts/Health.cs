using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int hp = 1;
    [SerializeField] bool isEnemy = true;
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] AudioClip hitSound;
    [SerializeField] private HealthBar healthBar;

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
                    DestroyShip(gameObject.GetComponent<Transform>().position);
                }
            }
        }
    }
    private void DestroyShip(Vector3 position)
    {
        ParticleSystem explosionEffect = Instantiate(explosionParticles, position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(explosionSound, position);
        explosionEffect.Play();
        Destroy(explosionEffect, 1f);
        
        Destroy(gameObject);
    }
}

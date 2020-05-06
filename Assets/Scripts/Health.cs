using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int hp = 1;
    [SerializeField] bool isEnemy = true;
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] AudioClip hitSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        Shot shot = collision.gameObject.GetComponent<Shot>();
        if(shot != null)
        {
            if(shot.isEnemyShot != isEnemy)
            {
                hp -= shot.damage;
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
        /*AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        AudioSource explosionAudioSource = Instantiate(audioSource, position, Quaternion.identity);
        AudioClip explosionAudio = Instantiate(explosionSound, position, Quaternion.identity);
        explosionAudioSource.PlayOneShot(explosionAudio);*/
        explosionEffect.Play();
        Destroy(explosionEffect, 1f);
        
        //Destroy(explosionAudio, 2f);
        //Destroy(explosionAudioSource, 2f);
        
        Destroy(gameObject);
    }
}

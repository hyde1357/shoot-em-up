using System.Collections;
using System.Collections.Generic;
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
                    audioSource.PlayOneShot(explosionSound);
                    DestroyShip();
                    /*explosionParticles.Play();
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    //gameObject.GetComponent<MeshCollider>().enabled = false;
                    gameObject.GetComponent<Weapon>().enabled = false;
                    Invoke("DestroyShip", 1f);*/
                }
            }
        }
    }
    private void DestroyShip()
    {
        Destroy(gameObject);
    }
}

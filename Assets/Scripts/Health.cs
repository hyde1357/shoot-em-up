using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int hp = 1;
    [SerializeField] bool isEnemy = true;
    [SerializeField] ParticleSystem explosionParticles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Shot shot = collision.gameObject.GetComponent<Shot>();
        if(shot != null)
        {
            if(shot.isEnemyShot != isEnemy)
            {
                hp -= shot.damage;
                Destroy(shot.gameObject);
                if(hp <= 0)
                {
                    explosionParticles.Play();
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    Invoke("DestroyShip", 1f);
                }
            }
        }
    }
    private void DestroyShip()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Collision : MonoBehaviour
{
    public Animator enemyAnimator;
    public Enemy enemyScript;
    public float deathAnimationLength;

    public void KillEnemy()
    {
        if(!enemyScript.isDead)
        {
            // play death animation
            enemyAnimator.SetTrigger("Death");
            deathAnimationLength = enemyAnimator.GetCurrentAnimatorClipInfo(0).Length;
            enemyScript.isDead = true; // mark to Dead
            gameObject.GetComponent<Enemy>().enabled = false; // stop moving
            //Destroy(collision.gameObject, enemyAnimator.GetCurrentAnimatorClipInfo(0).Length);
            Destroy(gameObject, deathAnimationLength);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            KillEnemy();
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource bGM;
    [SerializeField] private AudioSource damageSound;
    public bool dead;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            die();
        }
    }

    public void die()
    {
        // Trigger only once
        if(!dead){
            damageSound.Play();
            dead = true;
            anim.SetTrigger("Death");
            bGM.Pause();
            deathSound.Play();
            rb.bodyType = RigidbodyType2D.Static;
            StartCoroutine(overGame());
        }
    }

    IEnumerator overGame ()
    {
        yield return new WaitForSeconds(1);
        PlayerManager.isGameOver = true;
    }

}

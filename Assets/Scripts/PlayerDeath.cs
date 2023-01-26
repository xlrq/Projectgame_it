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

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            bGM.Pause();
            die();
        }
    }

    public void die()
    {
        anim.SetTrigger("Death");
    }

}

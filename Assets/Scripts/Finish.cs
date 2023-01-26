using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource finishSound;

    private void Start()
    {        
        rb = player.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Raise");
        finishSound.Play();
        StartCoroutine(completeLevel());
    }

    IEnumerator completeLevel()
    {
        yield return new WaitForSeconds(2);
        PlayerManager.isLevelCompleted = true;
    }
}

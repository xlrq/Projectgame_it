using UnityEngine;

public class EnemyProjectile : MonoBehaviour // Will damage the player every time they touch
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private float lifetime;

    [SerializeField] private float resetTime;
    
    private Animator anim;
    private BoxCollider2D boxCollider;

    private Health playerHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        boxCollider.enabled = true;
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("Explode");
        if (collision.tag == "Player")
            collision.GetComponent<Health>().TakeDamage(1);

        /*hit = true;
        base.OnTriggerEnter2D(collision); //Execute logic from parent script first
        coll.enabled = false;*/

        if (anim != null)
            anim.SetTrigger("Explode"); //When the object is a fireball explode it
        else 
            gameObject.SetActive(false); // deactivates when it hits an object
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
 
}

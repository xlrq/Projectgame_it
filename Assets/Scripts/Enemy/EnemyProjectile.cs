using UnityEngine;

public class EnemyProjectile : MonoBehaviour // Will damage the player every time they touch
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private float lifetime;

    private float resetTime = 3;
    
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
        if (collision.tag == "Player"){
            hit = true;
            boxCollider.enabled = false;

            collision.GetComponent<Health>().TakeDamage(1);
            gameObject.SetActive(false); 
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
 
}

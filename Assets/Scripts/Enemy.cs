using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public Transform[] waypoints;

    private SpriteRenderer graphics;
    private Transform target;
    private int destPoint = 0;

    void Start()
    {
        graphics = GetComponent<SpriteRenderer>();
        target = waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //si lenemi est quasi arrivé à sa destination
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.contacts[0].point.y > transform.position.y && collision.collider.GetType() == typeof(BoxCollider2D))
            {
                print("Enemy krabouillé");
                Destroy(gameObject);
            }
        }
    }

}

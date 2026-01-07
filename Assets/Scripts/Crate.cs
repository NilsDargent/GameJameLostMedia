using UnityEngine;

public class Crate : MonoBehaviour
{
    [SerializeField]
    private int Score;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.contacts[0].point.y > transform.position.y && collision.collider.GetType() == typeof(BoxCollider2D))
            {
                GameManager.Instance?.IncrementScore(Score);
                Destroy(gameObject);
            }
        }
    }

}

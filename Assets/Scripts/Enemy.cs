using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy : MonoBehaviour
{
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

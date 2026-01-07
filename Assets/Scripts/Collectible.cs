using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Collectible : MonoBehaviour
{
    [SerializeField]
    private int Score;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance?.IncrementScore(Score);
        Destroy(gameObject);
    }
}

using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("+1 disque");
        Destroy(gameObject);
    }
}

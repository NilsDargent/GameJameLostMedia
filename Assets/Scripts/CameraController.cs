using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform Player;

    [SerializeField]
    private Vector3 Offset;

    [SerializeField]
    private float Smoothing;

    [SerializeField]
    private float MinY;


    private Vector3 targetPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = Player.position + Offset;
        float ActuallOffset = -(targetPosition.y - transform.position.y);

        if (ActuallOffset > Offset.y + 1)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Smoothing * Time.deltaTime * ActuallOffset);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Smoothing * Time.deltaTime);
        }


        if (transform.position.y < MinY)
        {
            transform.position = new Vector3(transform.position.x, MinY, transform.position.z);
        }
    }
}

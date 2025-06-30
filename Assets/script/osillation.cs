using UnityEngine;

public class osillation : MonoBehaviour
{
    [SerializeField]float Speed;
    [SerializeField]Vector3 movementVector;
    Vector3 startingPosition;
    Vector3 endingPosition;
    float Movementfactor;

    
    void Start()
    {
        startingPosition = transform.position;
        endingPosition = startingPosition + movementVector;
    }

    void Update()
    {
        Movementfactor = Mathf.PingPong(Time.time * Speed, 1f);
        transform.position = Vector3.Lerp(startingPosition, endingPosition, Movementfactor);
    }
}

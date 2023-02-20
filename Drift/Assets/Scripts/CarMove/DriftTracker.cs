using UnityEngine;

public class DriftTracker : MonoBehaviour
{
    [SerializeField] float currentLapDistance;
    [SerializeField] float distanceToStart;

    private Vector3 lastPosition;
    Vector3 startPosition;

    void Start()
    {
        ResetPosition();
    }
    
    void Update()
    {
        //TODO: Create methods
        float distance = Vector3.Distance(transform.position, lastPosition);
        currentLapDistance += distance;
        lastPosition = transform.position;

        distanceToStart = Vector3.Distance(transform.position, startPosition);

        if( distanceToStart <= 0.1f & currentLapDistance > 0.5f )
        {
            currentLapDistance = 0;
        }
    }

    public void ResetPosition()
    {
        lastPosition = transform.position;
        startPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ResetPosition();
            print("!!!");
        }
    }
}

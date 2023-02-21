using UnityEngine;

public class DriftTracker : MonoBehaviour
{
    [SerializeField] Transform tracker;

    private Vector3 lastPosition;
    float currentLapDistance;
    float maxDistance;
    bool isDrifting = false;

    public float CurrentLapDistance {get => currentLapDistance;}
    public bool IsDrifting {get => isDrifting;}

    void Start()
    {
        maxDistance = GetComponent<SelectTarget>().circleDistance;
    }
    
    void Update()
    {
        //TODO: create methods
        if(isDrifting)
        {
            float distance = Vector3.Distance(lastPosition, tracker.position);
            currentLapDistance += distance;
            lastPosition = tracker.position;

            if (currentLapDistance >= maxDistance)
            {
                currentLapDistance = 0;
                isDrifting = false;
            }
        }
    }

    void ResetPosition()
    {
        isDrifting = true;
        lastPosition = tracker.position;
        currentLapDistance = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" & !isDrifting)
        {
            ResetPosition();
        }
    }
}

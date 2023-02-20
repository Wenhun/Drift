using UnityEngine;

public class SelectTarget : MonoBehaviour
{
    [SerializeField] Transform leftPointer;
    [SerializeField] Transform rightPointer;

    RaycastHit hit;
    Transform currentTarget;
    public Vector3 GetTarget { get => currentTarget.position; }

    void Start()
    {
        currentTarget = leftPointer.gameObject.transform;
    }

    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (Physics.Raycast(GetRay(), out hit))
            {
                transform.position = hit.point;
            }

            if(currentTarget == leftPointer)
            {
                currentTarget = rightPointer;
            }
            else
            {
                currentTarget = leftPointer;
            }
        }
    }

    static Ray GetRay()
    {
        return Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
    }
    
}

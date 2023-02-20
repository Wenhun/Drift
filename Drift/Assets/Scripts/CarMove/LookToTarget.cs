using UnityEngine;

public class LookToTarget : MonoBehaviour
{
    [SerializeField] Transform target;

    void Update()
    {
        transform.LookAt(target);
    }
}

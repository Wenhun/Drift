using UnityEngine;

public class RotateTarget : MonoBehaviour
{
    [SerializeField] Transform car;

    void Update()
    {
        transform.LookAt(car);
    }
}

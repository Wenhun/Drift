using UnityEngine;
using TMPro;

namespace Drift.DriftUIElements
{
    public class DriftPointsText : MonoBehaviour
    {
        [SerializeField] TMP_Text pointsText;

        Camera _camera;

        void Start()
        {
            _camera = Camera.main;
        }

        public void textChange(int points)
        {
            pointsText.text = points.ToString();
        }

        void LateUpdate()
        {
            transform.LookAt(new Vector3(transform.position.x, _camera.transform.position.y, transform.position.z));
            transform.Rotate(0, 180, 0);
        }

        void OnEnable()
        {
            pointsText.enabled = true;
        }

        void OnDisable()
        {
            pointsText.enabled = false;
        }
    }

}
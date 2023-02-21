using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] DriftTracker driftTracker;
    [SerializeField] Image bar;
    [SerializeField] Animator imageAnimator;

    float maxValue;

    void Start()
    {
        maxValue = driftTracker.GetComponent<SelectTarget>().circleDistance;
    }

    void Update()
    {
        bar.fillAmount = driftTracker.CurrentLapDistance / maxValue;
        imageAnimator.SetFloat("danger", bar.fillAmount);
    }
}

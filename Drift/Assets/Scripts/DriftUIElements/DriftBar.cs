using UnityEngine;
using UnityEngine.UI;

namespace Drift.DriftUIElements
{
    public class DriftBar : MonoBehaviour
    {
        [SerializeField] Image bar;
        [SerializeField] Animator imageAnimator;

        public void BarChange(float circleDistance, float maxValue)
        {
            bar.fillAmount = circleDistance / maxValue;
            imageAnimator.SetFloat("danger", bar.fillAmount);
        }
    }
}

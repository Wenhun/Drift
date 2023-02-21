using UnityEngine;
using TMPro;

namespace Drift.DriftUIElements
{
    public class TotalPointsText : MonoBehaviour
    {
        [SerializeField] TMP_Text totalCountText;

        public void textChange(int text)
        {
            totalCountText.text = text.ToString();
        }
    }
}
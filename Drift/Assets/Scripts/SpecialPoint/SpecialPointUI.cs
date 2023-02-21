using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Drift.SpecialPoint
{
    public class SpecialPointUI : MonoBehaviour
    {
        [SerializeField] List<Image> starImage;

        public void FillStar()
        {
            foreach(Image star in starImage)
            {
                if(star.fillAmount == 0)
                {
                    star.fillAmount = 1f;
                    break;
                }
            }
        }
    }
}
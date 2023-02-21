using UnityEngine;
using Drift.CarMove;

namespace Drift.DriftUIElements
{
    public class DirectionArrow : MonoBehaviour
    {
        [Header("Click Event")]
        [SerializeField] SelectTarget selectTarget;
        [Header("Trackers")]
        [SerializeField] Transform leftTacker;
        [SerializeField] Transform rightTacker;
        
        Animator animateIcon;
        SpriteRenderer directionIcon;

        bool isCorrectConfigured = false;

        void Start()
        {
            animateIcon = GetComponent<Animator>();
            directionIcon = GetComponent<SpriteRenderer>();

            //Parameters Check
            if(directionIcon.flipY)
            {
                isCorrectConfigured = true;
            }
            else
            {
                Debug.Log("Object: " + this.gameObject.name + " -> Parameters Are Incorrectly Configured: \n" +
                        "FlipY must be have true");
            }

            selectTarget.newPoint += ChangeTarget;
        }

        void OnDestroy()
        {
            selectTarget.newPoint -= ChangeTarget;
        }

        void ChangeTarget()
        {
            if(!isCorrectConfigured) Debug.Log("The initial value of FlipY is not set, the display of the object may not be correct");

            Transform currentTarget = selectTarget.GetTarget;

            if (currentTarget == leftTacker)
            {
                currentTarget = rightTacker;
                animateIcon.SetTrigger("right");
                directionIcon.flipY = false;
            }
            else
            {
                currentTarget = leftTacker;
                animateIcon.SetTrigger("left");
                directionIcon.flipY = true;
            }
        }
    }
}
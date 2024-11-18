using UnityEngine;

public class YellowBubble : Bubble
{   
    [SerializeField] private float minTapHoldTime;

    protected override bool BlowCondition()
    {
        Touch touch = Input.GetTouch(0);

        if (TargetCheck(touch))
        {
            tapMade = true;

            if (touch.phase == TouchPhase.Ended && tapTimer < minTapHoldTime) ResetCondition();

            if (tapMade) tapTimer += Time.deltaTime;

            if (tapTimer >= minTapHoldTime) return true;
        }
        return false;
    }   
}

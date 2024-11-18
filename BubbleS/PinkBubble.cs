using UnityEngine;

public class PinkBubble :Bubble
{
    [SerializeField] float minSwapDistance;

    private Vector2 _startPosition;
    protected override bool BlowCondition()
    {
        Touch touch = Input.GetTouch(0);
        if (TargetCheck(touch))
        {
            if (touch.phase == TouchPhase.Began)
                _startPosition = touch.position;

            Vector2 deltaPosition = touch.position - _startPosition;

            if (deltaPosition.magnitude >= minSwapDistance) return true;
        }        
        return false;
    }    
}

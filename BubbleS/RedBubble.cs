using UnityEngine;

public class RedBubble :Bubble
{
    [SerializeField] private float maxTimeBetweenTaps;    

    protected override bool BlowCondition()
    {        
        if (tapMade) tapTimer += Time.deltaTime;
        if (tapTimer >= maxTimeBetweenTaps) ResetCondition();
        
        Touch touch = Input.GetTouch(0);
        if (TargetCheck(touch))
        {
            if (tapMade && tapTimer < maxTimeBetweenTaps) return true;
            
            if (touch.phase == TouchPhase.Ended) tapMade = true;                    
        }    
        return false;
    }   
}

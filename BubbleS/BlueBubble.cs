using UnityEngine;

public class BlueBubble : Bubble
{     
    protected override bool BlowCondition()
    {
        Touch touch = Input.GetTouch(0);

        return TargetCheck(touch);            
    }          
}

using System;
using UnityEngine;

public abstract class Bubble : MonoBehaviour
{
    [SerializeField] private float lifetime;

    protected float timer;
    protected bool tapMade;
    protected float tapTimer;  

    public static Action OnBlow;

    protected void Update()
    {
        if (Input.touchCount > 0 && BlowCondition())
            ConditionReached();
        
        TimerCheck();     
    }

    protected abstract bool BlowCondition();
    
    protected void TimerCheck()
    {
        timer += Time.deltaTime;
        if (timer > lifetime)
            ReturnToQueue();
    }
    private void ReturnToQueue()
    {
        ResetCondition();
        gameObject.SetActive(false);
        BubbleSpawner._bubbles.Enqueue(this);
    }
    protected virtual void ResetCondition()
    {
        tapMade = false;
        tapTimer = 0;
        timer = 0;
    }
    protected bool TargetCheck(Touch touch)
    {

        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == this.gameObject)
            return true;
        else return false;
    }
    protected void ConditionReached()
    {
        ReturnToQueue();
        OnBlow?.Invoke();
    }
}

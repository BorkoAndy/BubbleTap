using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField] private Bubble[] bubblePrefabs;
    [SerializeField] private BoxCollider2D viewportRectangle;    
    [SerializeField] private int bubblesAmount;
    [SerializeField] private float spawningFrequence;
    [SerializeField] private float spawningFrequenceUnIncreaseable;
    [SerializeField] private float spawningLevelTimeDelta;
    
    private float _screenWidth;
    private float _screenHeight;

    public static  Queue<Bubble> _bubbles;

    private void OnEnable() => GamePlayScreen.OnLevelIncrease += LevelIncrease;
    private void OnDisable() => GamePlayScreen.OnLevelIncrease -= LevelIncrease;

    private void Start()
    {
        _bubbles = new Queue<Bubble>();
        _screenWidth = viewportRectangle.size.x;
        _screenHeight = viewportRectangle.size.y;
       
        QueueCreate(bubblesAmount);        
        StartCoroutine(Spawn());        
    }

    private void QueueCreate(int bubblesAmount)
    {
        for (int i = 0; i < bubblesAmount; i++)
        {
            Bubble newBubble = CreateNewBubble();
            newBubble.gameObject.SetActive(false);
            newBubble.transform.parent = transform;
            _bubbles.Enqueue(newBubble);
        }
    }

    private Bubble CreateNewBubble() => Instantiate(bubblePrefabs[Random.Range(0, bubblePrefabs.Length)]);
    private IEnumerator Spawn()
    {
        while (true)
        {
            Vector2 _spawnPosition = new Vector2(Random.Range(-_screenWidth / 2, _screenWidth / 2), Random.Range(-_screenHeight / 2, _screenHeight / 2));
            Bubble newBubble;
            if (_bubbles.Count == 0) 
               newBubble = CreateNewBubble(); 
            else newBubble = _bubbles.Dequeue();           

            newBubble.transform.position = _spawnPosition;
            newBubble.gameObject.SetActive(true);
            yield return new WaitForSeconds(spawningFrequence);
        }
    }
    private void LevelIncrease()
    {
        if(spawningFrequence > spawningFrequenceUnIncreaseable)
            spawningFrequence -= spawningLevelTimeDelta;
    }
}

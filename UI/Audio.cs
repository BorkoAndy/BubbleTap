using UnityEngine;

public class Audio : MonoBehaviour
{
  
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip bubblePopSound;


    public static Audio Instance;
    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);             
                
        DontDestroyOnLoad(this);
    }
    private void OnEnable()
    {
        Bubble.OnBlow += BubblePop;
        SettingsScreen.MusicPlay += PlayMusic;
    }

    private void OnDisable()
    {
        Bubble.OnBlow -= BubblePop;
        SettingsScreen.MusicPlay -= PlayMusic;
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMusic(PersistanceData.isMusic);
    }

    private void PlayMusic(bool musicIsOn)
    {
        if(!musicIsOn) audioSource.Stop(); 
        else audioSource.Play();
    }   

    private void BubblePop()
    {
        if(PersistanceData.isSound)
            audioSource.PlayOneShot(bubblePopSound);
    }
}

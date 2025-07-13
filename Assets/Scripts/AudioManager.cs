using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    private AudioSource audioSource;
    private void Awake()
    {
        // Singleton pattern used as instance of this manager is created and assigned to this manager 
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); //this null check is to ensure that the instace is not assigned to 
            // this before hand and that its empty and also to prevent duplicates 
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scenes that means when new scene is loaded, 
        //this manager will be present in the new transitioned scene when the previous one is unloaded
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
            audioSource.PlayOneShot(clip);
    }
    public void PlayLoop(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
    public void StopSound()
    {
        audioSource.Stop();
    }
}

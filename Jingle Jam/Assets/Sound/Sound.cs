using UnityEngine;

public class Sound : MonoBehaviour
{
    private static Sound instance;
    public AudioClip[] soundClips;
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(int soundIndex)
    {
        // Check if the sound index is valid
        if (soundIndex < 0 || soundIndex >= soundClips.Length)
        {
            Debug.LogError("Invalid sound index: " + soundIndex);
            return;
        }

        // Set the audio source's clip to the selected sound clip
        audioSource.clip = soundClips[soundIndex];

        // Play the sound
        audioSource.Play();
    }

    public static Sound GetInstance()
    {
        return instance;
    }
}

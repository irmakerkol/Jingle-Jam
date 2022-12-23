using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    private static Sound instance;
    public AudioClip[] soundClips;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Image soundOnImage, soundOffImage;

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

    public bool soundsEnabled = true;

    public void PlaySound(int soundIndex)
    {
        // Check if sounds are enabled
        if (!soundsEnabled)
        {
            return;
        }

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

    public void ToggleSound()
    {
        if (soundsEnabled)
        {
            soundOnImage.gameObject.SetActive(false);
            soundOffImage.gameObject.SetActive(true);
            soundsEnabled = false;
        }
        else
        {
            soundOffImage.gameObject.SetActive(false);
            soundOnImage.gameObject.SetActive(true);
            soundsEnabled = true;
        }
    }



    public static Sound GetInstance()
    {
        return instance;
    }
}

using UnityEngine;
using UnityEngine.Audio;

public class AudioControl : MonoBehaviour
{   
    private AudioSource AS;

    public static AudioControl instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

  public void Tocar_SFX(AudioClip clip)
    {
        AS.clip = clip;
        AS.Play();
    }
   
}

using UnityEngine;
using UnityEngine.Audio;

public class AudioControl : MonoBehaviour
{   
    private AudioSource AS;

    private AudioControl instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
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

using UnityEngine;
using UnityEngine.Audio;

public class AudioControl : MonoBehaviour
{   
    private AudioSource AS;

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

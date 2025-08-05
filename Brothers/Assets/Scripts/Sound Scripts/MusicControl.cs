using UnityEngine;

public class MusicControl : MonoBehaviour
{
    private static MusicControl instance; 

    private AudioSource Music_AS;

    [SerializeField]
    private AudioClip[] musicas;
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
        Music_AS = GetComponent<AudioSource>();
        tocarMusica();
    }

    // Update is called once per frame
    void Update()
    {
        if (Music_AS.isPlaying == false)
        {
            tocarMusica();
        }
    }

    private void tocarMusica()
    {
        int index = Random.Range(0, musicas.Length - 1);
        Music_AS.clip = musicas[index];
        Music_AS.Play();    
    }
}

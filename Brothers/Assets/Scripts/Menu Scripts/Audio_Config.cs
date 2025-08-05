using UnityEngine;
using UnityEngine.UI;

public class Audio_Config : MonoBehaviour
{
    //Vao controlar o volume dos audios 
    private AudioSource Musica_AS,Sons_AS;

    //Controla a animacao de aparecer as configuracoes
    private RectTransform Config_pos;

    [SerializeField]
    private Slider Musica_Slider,Sons_Slider;

    private void Awake()
    {
        //Atribui os objetos
        Musica_AS = GameObject.Find("MusicSourceOBJ").GetComponent<AudioSource>();
        Sons_AS = GameObject.Find("AudioSourceOBJ").GetComponent<AudioSource>();
        Config_pos = GameObject.Find("ConfigBG").GetComponent<RectTransform>();
    }

    private void Start()
    {
        //Checa se tem salvo na memoria 
        if (PlayerPrefs.HasKey("Vol_musica"))
        {
            Musica_AS.volume = PlayerPrefs.GetFloat("Vol_musica");
            Musica_Slider.value = PlayerPrefs.GetFloat("Vol_musica");
        }
        else
        {
            Musica_AS.volume = 1;
        }
        if (PlayerPrefs.HasKey("Vol_sons"))
        {
            Sons_AS.volume = PlayerPrefs.GetFloat("Vol_sons");
            Sons_Slider.value = PlayerPrefs.GetFloat("Vol_sons");
        }
        else 
        {
            Sons_AS.volume=1;
        }
    }

    public void ShowConfig() 
    {
        Config_pos.LeanMoveX(0f, 0.8f);
    }

    public void HideConfig()
    {
        Config_pos.LeanMoveX(-600f, 0.8f);
    }

    public void Musica_Vol(float vol) 
    {
        Musica_AS.volume = vol;
        PlayerPrefs.SetFloat("Vol_musica", vol);
    }

    public void Sons_Vol(float vol)
    {
        Sons_AS.volume = vol;
       PlayerPrefs.SetFloat("Vol_sons", vol);
    }

}

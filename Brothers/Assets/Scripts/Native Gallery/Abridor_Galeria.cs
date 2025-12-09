using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Abridor_Galeria : MonoBehaviour
{
 [SerializeField]
 private Image image;
 private Transform imageTransform;
 [SerializeField]
 private Texture2D tex;

 [SerializeField]
 Button abrirGaleriaButton;
 private static Abridor_Galeria instance;

    void Awake()
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

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnsceneLoaded;
    }
    //Quando a cena de criar fase iniciar checar se o ha alguma textura presente
    public void OnsceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Tela_Inicial")
        {
          //Acha o botão e atribui a função de abrir a galeria
          abrirGaleriaButton = GameObject.Find("GaleryButton").GetComponent<Button>();
          abrirGaleriaButton.onClick.AddListener(AbrirGaleria);
          if(tex != null)
            {
         imageTransform = GameObject.Find("ImageBG").transform;     
         image = imageTransform.Find("Word_Image").GetComponent<Image>();
         Debug.Log("Rodei dnv");
         image.sprite = null;
         //Cria um sprite a partir da textura carregada e atribui para a imagem da UI
         Sprite sp = Sprite.Create(tex, new Rect(0f,0f,tex.width,tex.height), new Vector2(0.5f,0.5f));
         image.sprite = sp;
         image.gameObject.SetActive(true);
            }
        }
    }
    

    //Função que chama a Bibliotéca Native Gallery
    public void AbrirGaleria()
    {
        NativeGallery.GetImageFromGallery((path) =>
        {
          //chaca se há um caminho para a path
        if(path != null)
            {
              //Carrega uma textura a partir da imagem selecionada
               tex = NativeGallery.LoadImageAtPath(path);
                if(tex != null)
            {
              //Cria um sprite a partir da textura carregada e atribui para a imagem da UI
                Sprite sp =Sprite.Create(tex, new Rect(0f,0f,tex.width,tex.height), new Vector2(0.5f,0.5f));
                image.gameObject.SetActive(true);
                image.sprite = sp;
            }
            }    
        },"Selecione uma imagem");
    }
}

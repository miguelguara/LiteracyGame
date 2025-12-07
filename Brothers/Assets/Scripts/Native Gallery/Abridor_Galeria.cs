using UnityEngine;
using UnityEngine.UI;

public class Abridor_Galeria : MonoBehaviour
{
 [SerializeField]
 private Image image;

//Função que chama a Bibliotéca Native Gallery
 public void AbrirGaleria()
    {
        NativeGallery.GetImageFromGallery((path) =>
        {
          //chaca se há um caminho para a path
        if(path != null)
            {
              //Carrega uma textura a partir da imagem selecionada
                Texture2D tex = NativeGallery.LoadImageAtPath(path);
                if(tex != null)
            {
              //Cria um sprite a partir da textura carregada e atribui para a imagem da UI
                Sprite sp =Sprite.Create(tex, new Rect(0f,0f,tex.width,tex.height), new Vector2(0.5f,0.5f));
                image.sprite = sp;
            }
            }    
        },"Selecione uma imagem");
    }
}

using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public Text TextoMenu;
    [SerializeField]
    private RectTransform Pannel_Levels;

    public void Start()
    {
        TextoMenu.gameObject.LeanScale(new Vector3(1.3f,1.3f),0.45f).setLoopPingPong();
    }
    
    public void PannelIN()
    {
        Pannel_Levels.LeanMoveX(30f, 1f);
    }

    public void PannelOUT() 
    {
        Pannel_Levels.LeanMoveX(820f, 0.7f);
    }
}

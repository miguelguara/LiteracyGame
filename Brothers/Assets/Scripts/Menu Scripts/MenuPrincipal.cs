using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public Image Logo;
    [SerializeField]
    private RectTransform Pannel_Levels;

    public void Start()
    {
        Logo.gameObject.LeanScale(new Vector3(1f,1f),0.45f).setLoopPingPong();
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

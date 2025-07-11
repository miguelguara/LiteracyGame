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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
                Pannel_Levels.LeanMoveX(30f, 1f).setEaseInBounce();
                Debug.Log("VC APERTOU!");   
        }
        /*else if(Input.GetKeyDown(KeyCode.Escape))  
        {
            Pannel_Levels.LeanMoveX(820f, 0.3f);
        }*/
    }
}

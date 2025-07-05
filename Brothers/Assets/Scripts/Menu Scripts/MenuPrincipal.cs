using UnityEngine;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public Text TextoMenu;

    public void Start()
    {
        TextoMenu.gameObject.LeanScale(new Vector3(1.3f,1.3f),0.45f).setLoopPingPong();
    }
}

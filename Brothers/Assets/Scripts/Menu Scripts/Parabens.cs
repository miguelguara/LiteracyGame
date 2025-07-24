using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Parabens : MonoBehaviour
{
    [SerializeField]
    private int FaseIndex;

   public void Reload() 
    {
        FaseIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(FaseIndex);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}

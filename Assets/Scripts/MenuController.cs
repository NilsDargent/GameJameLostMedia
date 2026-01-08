using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject option;

    public void OnStart()
    {
        SceneManager.LoadScene(1);
    }

    public void Credit()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByName("Credit").name);
    }
    public void Options()
    {
        option.SetActive(true);

    }

    public void Quit()
    {
        Application.Quit();
    }
}

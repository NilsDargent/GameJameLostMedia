using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject option;

    [SerializeField]
    private AudioMixer audioMixer;

    public void OnStart()
    {
        SceneManager.LoadScene(1);
    }

    public void Credit()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);
    }
}

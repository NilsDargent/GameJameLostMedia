using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(0);
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class quitgame : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.escapeKey.isPressed)
        {
            Application.Quit();
        }
    }
}

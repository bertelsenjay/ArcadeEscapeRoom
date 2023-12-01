using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class PauseMenu : MonoBehaviour
{

    public GameObject canvas;
    public GameObject teleportRay; 
    public bool isCanvasActive = true; 
    // Start is called before the first frame update
    void Start()
    {
        DisplayUI();
    }

    

    public void DisplayUI()
    {
        if (isCanvasActive)
        {
            canvas.SetActive(false);
            teleportRay.SetActive(false);
            isCanvasActive = false;
            Time.timeScale = 1;
        }
        else if (!isCanvasActive)
        {
            canvas.SetActive(true);
            teleportRay.SetActive(true);
            isCanvasActive = true;
            Time.timeScale = 0; 
        }
    }

    public void PauseButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            DisplayUI(); 
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    } 
}

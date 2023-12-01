using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class PauseMenu : MonoBehaviour
{

    public GameObject canvas;
     
    public bool isCanvasActive = true;
    LocomotionSystem locomotionSystem; 
    // Start is called before the first frame update
    void Start()
    {
        locomotionSystem = FindObjectOfType<LocomotionSystem>()
        DisplayUI();
    }

    

    public void DisplayUI()
    {
        if (isCanvasActive)
        {
            canvas.SetActive(false);
            
            isCanvasActive = false;
            Time.timeScale = 1;
        }
        else if (!isCanvasActive)
        {
            canvas.SetActive(true);
            
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

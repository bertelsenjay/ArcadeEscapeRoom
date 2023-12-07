using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class PauseMenu : MonoBehaviour
{

    public GameObject canvas;
    public GameObject confirmationCanvas; 
    public bool isCanvasActive = true;
    LocomotionSystem locomotionSystem; 
    TeleportationProvider teleportationProvider;
    ActivateTPRay activateTPRay; 
    // Start is called before the first frame update
    void Start()
    {
        locomotionSystem = FindObjectOfType<LocomotionSystem>();
        teleportationProvider = FindObjectOfType<TeleportationProvider>();
        //activateTPRay = FindObjectOfType<ActivateTPRay>();
        DisplayUI();
        confirmationCanvas.SetActive(false); 
    }

    

    public void DisplayUI()
    {
        if (isCanvasActive)
        {
            canvas.SetActive(false);
            //locomotionSystem.enabled = true;
            teleportationProvider.enabled = true;
            //activateTPRay.enabled = true;
            isCanvasActive = false;
            Time.timeScale = 1;
        }
        else if (!isCanvasActive)
        {
            canvas.SetActive(true);
            //locomotionSystem.enabled = false; 
            teleportationProvider.enabled = false;
            //activateTPRay.enabled = false;
            isCanvasActive = true;
            Time.timeScale = 0; 
        }
    }

    public void PauseButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            DisplayUI(); 
    }

    public void ShowConfirmation()
    {
        confirmationCanvas.SetActive(true);
    }

    public void DismissConfirmation()
    {
        confirmationCanvas.SetActive(false);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayUI();
        }
    }

}

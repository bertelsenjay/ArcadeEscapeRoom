using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject difficultySelector; 
    void Start()
    {
        difficultySelector.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            LoadDifficultySelect();
        }
    }


    public void LoadDifficultySelect()
    {
        //SceneManager.LoadScene("DifficultySelect");
        difficultySelector.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Application Closed");
        Application.Quit();
    }
}

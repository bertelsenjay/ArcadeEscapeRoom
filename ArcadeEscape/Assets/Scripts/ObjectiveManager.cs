using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ObjectiveManager : MonoBehaviour
{
    public string[] objectives;
    public int index = 0;
    public TextMeshProUGUI objectiveText;


    private void Update()
    {
        objectiveText.text = objectives[index];
        
    }

    public void IncrementIndex()
    {
        if (index >= objectives.Length) { return; }
        index++;
    }
}

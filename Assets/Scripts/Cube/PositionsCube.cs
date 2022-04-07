using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionsCube : MonoBehaviour
{

    public Transform first;
    public Transform second;


    public void Start()
    {
        Application.targetFrameRate = 60;
    }
    private void Update()
    {

      second.LookAt(first);

    }
}    
        


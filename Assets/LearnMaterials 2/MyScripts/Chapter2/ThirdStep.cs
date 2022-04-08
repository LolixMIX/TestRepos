using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdStep : SampleScript
{
    public Transform startPosition;

    [SerializeField]
    private int step;
    public Vector3 whereToSpawn;
    
    
    private float localPosition;

    public GameObject CloneCube;

    public int Counter;
    public float CoolDown;


    private void Start()
    {
        StartCoroutine(SpawnCD());
    }
    void Repeat()
    {
        Counter--;
        if (Counter != 0)
        {
            StartCoroutine(SpawnCD());
            
        }
        
    }
    IEnumerator SpawnCD()
    {

        yield return new WaitForSeconds(CoolDown);
        whereToSpawn = new Vector3(localPosition, transform.position.y,transform.position.z);
        Instantiate(CloneCube, whereToSpawn, Quaternion.identity);
        localPosition += step;
        Repeat();
    }
    public override void Use()
    {
        


    }

    void Update()
    {
        
    }
}

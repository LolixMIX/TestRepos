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

    [Range(0,10)]
    public int Counter;
    private int startCounter;

    [Min(0)]
    public float CoolDown;


    [SerializeField]
    private bool _key;

    private void Start()
    {
        
    }
    void Repeat()
    {
        Debug.Log($"Каунтер {Counter}");
        Counter--;
        if (Counter != 0)
        {
            StartCoroutine(SpawnCD());     
        }
    }
    IEnumerator SpawnCD()
    {

        
        whereToSpawn = new Vector3(localPosition, transform.position.y,transform.position.z);
        Instantiate(CloneCube, whereToSpawn, Quaternion.identity);
        localPosition += step;
        yield return new WaitForSeconds(CoolDown);
        Repeat();

    }

    [ContextMenu("Активировать скрипт")]
    public override void Use()
    {
        startCounter = Counter;
        StartCoroutine(SpawnCD());
        if (Counter == 0)
        {
            Debug.Log($"Созданно объектов {startCounter}");
        }
    }

    void Update()
    {


    }
}

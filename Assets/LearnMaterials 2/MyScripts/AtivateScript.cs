using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivateScript : MonoBehaviour
{

    [SerializeField]
    List<SampleScript> sampleScripts;


    [ContextMenu("Активировать все скрипты")]
    void Activate()
    {

        foreach (var item in sampleScripts)
        {
            item.Use();
        }

    }

}

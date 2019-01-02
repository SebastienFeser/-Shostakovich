using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyContainer : FixObject
{

    [SerializeField] private bool containsKey;
    
    
// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interaction()
    {
        if (containsKey == true)
        {
            Dialog.ShowDialog();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTest>().Key = true;
            containsKey = false;
        }
        else 
        {
            Dialog.ShowAlternativeDialog();
        }
    }
}

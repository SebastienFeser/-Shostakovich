using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectContainer : FixObject
{

    [SerializeField] private bool containsObject;
    [SerializeField] private string objectName;
    
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
        if (containsObject == true)
        {
            Dialog.ShowDialog();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTest>().NewInventory(objectName);
            containsObject = false;
        }
        else 
        {
            Dialog.ShowAlternativeDialog();
        }
    }
}

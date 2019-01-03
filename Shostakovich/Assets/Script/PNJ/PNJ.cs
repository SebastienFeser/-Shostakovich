using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJ : FixObject
{
    [SerializeField] private string objectLookingFor;
    [SerializeField] private string objectToGive;

    [SerializeField] private bool objectGiven;
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
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTest>().SearchInInventory(objectLookingFor))
        {
            Dialog.ShowAlternativeDialog();
            if (!objectGiven)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTest>().NewInventory(objectToGive);
                objectGiven = false;
            }
        }
        else
        {
            Dialog.ShowDialog();
        }
    }
}

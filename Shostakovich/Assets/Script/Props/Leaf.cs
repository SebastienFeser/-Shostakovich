using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : FixObject
{
    [SerializeField] private bool objectContain;
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
        if (objectContain)
        {
            Dialog.ShowAlternativeDialog();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTest>().NewInventory(objectName);
        }
        else
        {
            Dialog.ShowDialog();
           
        }
    }
}

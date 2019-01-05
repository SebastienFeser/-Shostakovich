using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nikolai : FixObject
{
    [SerializeField] private string searchObject;
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

        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTest>().SearchInInventory(searchObject))
        {
            Dialog.ShowDialog();
        }
        else
        {
            Dialog.ShowAlternativeDialog();
        }
    }
}

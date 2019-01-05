using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Youri : FixObject
{
    [SerializeField] private string rewardObject;
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
        base.Interaction();
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTest>().SearchInInventory(rewardObject))
        {
            Dialog.ShowAlternativeDialog();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTest>().NewInventory(rewardObject);
        }
    }
}
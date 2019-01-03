using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Caretaker : FixObject
{
    [SerializeField] private SO_Interaction initialInteraction;
    [SerializeField] private SO_Interaction firstInteraction;
    [SerializeField] private SO_Interaction[] clues;
    [SerializeField] private SO_Interaction lastInteraction;

    [SerializeField] private string[] requiredObjects;
    private int interactionDone;

    private bool introduction = true;

    private bool doveFleeing = true;
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
        if (introduction)
        {
            initialInteraction.ShowDialog();
            introduction = false;
        } 
        if (!GameManager.Instance.DoveFlee)
        {
            firstInteraction.ShowDialog();
        }
        else
        {
            bool haveObjects = true;
            foreach (var requiredObject in requiredObjects)
            {
                if (!GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTest>().SearchInInventory(requiredObject))
                {
                    haveObjects = false;
                }
            }

            if (haveObjects)
            {
                lastInteraction.ShowDialog();
            }
            else
            {
                if (doveFleeing)
                {
                    firstInteraction.ShowAlternativeDialog();
                    doveFleeing = false;
                }

                foreach (var clue in clues)
                {
                    clue.ShowDialog();
                }
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Caretaker : FixObject
{
    public enum CaretakerState
    {
        INTRODUCTION,
        DOVE,
        CLUE,
        LAST,
    }

    [SerializeField] private SO_Interaction initialInteraction;
    [SerializeField] private SO_Interaction firstInteraction;
    [SerializeField] private SO_Interaction[] clues;
    [SerializeField] private SO_Interaction lastInteraction;

    [SerializeField] private string[] requiredObjects;
    private int interactionDone;

    private bool introduction = true;

    private bool doveFleeing = true;

    private CaretakerState currentState = CaretakerState.INTRODUCTION;
    
    [SerializeField] private bool containsObject;
    [SerializeField] private string objectName;
    // Start is called before the first frame update
    void Start()
    {
        currentState = GameManager.Instance.SaveDataInstance.currentState;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interaction()
    {

        bool haveObjects = true;
        foreach (var requiredObject in requiredObjects)
        {
            if (!GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTest>().SearchInInventory(requiredObject))
            {
                haveObjects = false;
            }
        }

        if (haveObjects && currentState == CaretakerState.CLUE)
        {
            currentState = CaretakerState.LAST;
        }
        if (GameManager.Instance.SaveDataInstance.doveFlee && currentState == CaretakerState.INTRODUCTION)
        {
            currentState = CaretakerState.DOVE;
        }


        switch (currentState)
        {
            case CaretakerState.INTRODUCTION:
            {
                initialInteraction.ShowDialog();
                firstInteraction.ShowDialog();
                break;
            }
            case CaretakerState.DOVE:
            {
                firstInteraction.ShowAlternativeDialog();

                currentState = CaretakerState.CLUE;
                foreach (var clue in clues)
                {
                    clue.ShowDialog();
                }
                break;
            }
            case CaretakerState.CLUE:
            {
                foreach (var clue in clues)
                {
                    clue.ShowDialog();
                }
                break;
            }
            case CaretakerState.LAST:
            {
                lastInteraction.ShowDialog();
                if (containsObject)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTest>().NewInventory(objectName);
                    containsObject = false;
                }
                
                break;
            }

        }
        
    }

    private void OnDestroy()
    {
        GameManager.Instance.SaveDataInstance.currentState = currentState;
    }
}

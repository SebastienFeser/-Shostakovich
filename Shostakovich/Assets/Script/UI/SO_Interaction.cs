using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialog")]
public class SO_Interaction : ScriptableObject
{
    [SerializeField] private string[] dialog;
    [SerializeField] private string[] alternativeDialog;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDialog()
    {
        if (UIManager.Instance.CurrentDialogState == UIManager.DialogState.NONE)
        { 
            UIManager.Instance.ShowDialog(dialog);
        }
        else
        {
            UIManager.Instance.WaitingDialogList.Add(dialog);
        }
    }
    public void ShowAlternativeDialog()
    {
        if (UIManager.Instance.CurrentDialogState == UIManager.DialogState.NONE)
        {

            UIManager.Instance.ShowDialog(alternativeDialog);
        }
        else
        {
            UIManager.Instance.WaitingDialogList.Add(alternativeDialog);
        }
    }
}

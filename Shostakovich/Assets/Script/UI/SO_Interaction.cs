using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialog")]
public class SO_Interaction : ScriptableObject
{
    [SerializeField] private string[] dialog;
    [SerializeField] private bool containsKey;
    
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
            Debug.Log("none");
            UIManager.Instance.ShowDialog(dialog);
        }

        if (containsKey == true)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTest>().Key = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public enum DialogState
    {
        NONE,
        CONTINUE,
        FINISH,
    }


    [SerializeField] private GameObject dialogWindow;
    
    [SerializeField] private static UIManager instance;
    public static UIManager Instance => instance;
    // Start is called before the first frame update
    private DialogState currentDialogState;
    public DialogState CurrentDialogState => currentDialogState;
    [SerializeField] private PlayerTest scriptPlayer;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            InteractionTest();
        }
    }

    public void InteractionTest()
    {
        switch (currentDialogState)
        {
            case (DialogState.CONTINUE):
            {
                break;
            }
            case (DialogState.FINISH):
            {
                dialogWindow.SetActive(false);
                Debug.Log("yesn't");
                currentDialogState = DialogState.NONE;
                scriptPlayer.enabled = true;
                break;
            }
        }

    }


    public void ShowDialog(string text)
    {
        dialogWindow.SetActive(true);
        dialogWindow.GetComponentInChildren<TextMeshProUGUI>().text = text;
        scriptPlayer.enabled = false;
        currentDialogState = DialogState.FINISH;
        
    }
}

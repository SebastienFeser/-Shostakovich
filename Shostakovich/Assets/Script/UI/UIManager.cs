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
    private DialogState currentDialogState = DialogState.NONE;
    public DialogState CurrentDialogState => currentDialogState;
    private int indexDialog = 0;
    private string[] currentDialog; 
    [SerializeField] private PlayerTest scriptPlayer;
    private List<string[]> waitingDialogList = new List<string[]>();
    public List<string[]> WaitingDialogList
    {
        get { return waitingDialogList; }
        set { waitingDialogList = value; }
    }

    void Start()
    {
        instance = this;
        
        scriptPlayer.enabled = false;
        scriptPlayer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && !scriptPlayer.enabled)
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
                ShowDialog(currentDialog);
                break;
            }
            case (DialogState.FINISH):
            {
                dialogWindow.SetActive(false);
                currentDialogState = DialogState.NONE;
                scriptPlayer.enabled = true;
                if (waitingDialogList.Count > 0)
                {
                    ShowDialog(waitingDialogList[0]);
                    waitingDialogList.RemoveAt(0);
                }

                break;

            }
        }
    }


    public void ShowDialog(string[] text)
    {
        scriptPlayer.enabled = false;
        dialogWindow.SetActive(true);
        dialogWindow.GetComponentInChildren<TextMeshProUGUI>().text = text[indexDialog];
        indexDialog++;
        if (text.Length > indexDialog)
        {
            currentDialog = text;
            currentDialogState = DialogState.CONTINUE;
        }
        else
        {
            indexDialog = 0;
            currentDialog = null;
            currentDialogState = DialogState.FINISH;
        }
    }
}

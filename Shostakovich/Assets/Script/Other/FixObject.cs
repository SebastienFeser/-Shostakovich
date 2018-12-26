using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixObject : MonoBehaviour
{
    [SerializeField] private bool interactive = false;
    public bool Interactive
    {
        get { return interactive; }
        set { interactive = value; }
    }

    
    [SerializeField] private bool wall = true;
    public bool Wall
    {
        get { return wall; }
        set { wall = value; }
    }
    
    
    [SerializeField] private SO_Interaction dialog;
    public SO_Interaction Dialog => dialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

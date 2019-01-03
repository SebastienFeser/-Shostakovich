using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool doveFlee = false;
    public bool DoveFlee
    {
        get { return doveFlee; }
        set { doveFlee = value; }
    }

    



    [SerializeField] private static GameManager instance;
    public static GameManager Instance => instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dove : FixObject
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.SaveDataInstance.doveFlee)
        {
            GameManager.Instance.SaveDataInstance.doveFlee = true;
            GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            Wall = false;
            Interactive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interaction()
    {
        base.Interaction();
        GameManager.Instance.SaveDataInstance.doveFlee = true;
        GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        Wall = false;
        Interactive = false;
    }
}

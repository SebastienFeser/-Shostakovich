using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dove : FixObject
{
    // Start is called before the first frame update
    [SerializeField] AudioSource pigeonSource;
    [SerializeField] AudioClip pigeonClip;
    void Start()
    {
        if (GameManager.Instance.SaveDataInstance.doveFlee)
        {
            GameManager.Instance.SaveDataInstance.doveFlee = true;
            GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0f);
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
        pigeonSource.clip = pigeonClip;
        pigeonSource.Play();
        base.Interaction();
        GameManager.Instance.SaveDataInstance.doveFlee = true;
        GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0f);
        Wall = false;
        Interactive = false;
    }
}

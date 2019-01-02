using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    private BoxCollider2D box;
    [SerializeField] private LayerMask raycastLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool DetectWall()
    {
        
        Collider2D collider = Physics2D.OverlapBox((Vector2)transform.position + box.offset, box.size, 0, raycastLayerMask);

        if (collider)
        {
            if (collider.GetComponent<FixObject>())
            {
                return collider.GetComponent<FixObject>().Wall;
            }

        }
        return false;
    }
    public FixObject DetectInteract()
    {
        Debug.Log("Interact");
        Collider2D[] colliders = Physics2D.OverlapBoxAll((Vector2)transform.position + box.offset, box.size, 0, raycastLayerMask);
        foreach (var collider in colliders)
        {
            if (collider)
            {
                if (collider.GetComponent<FixObject>())
                {
                    if (collider.GetComponent<FixObject>().Interactive)
                    {
                        Debug.Log("log");
                        return collider.GetComponent<FixObject>();
                    }
                }
            }
        }

        return null;
    }
}

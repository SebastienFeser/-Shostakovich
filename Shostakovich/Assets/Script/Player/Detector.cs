using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{

    private GameObject detectedGameObject;


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
        Debug.Log(collider);

        if (collider)
        {
            if (collider.GetComponent<FixObject>())
            {
                return collider.GetComponent<FixObject>().Wall;
            }
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        detectedGameObject = other.gameObject;
        Debug.Log("detected");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        detectedGameObject = null;
    }
}

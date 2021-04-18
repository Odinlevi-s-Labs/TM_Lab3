using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerriesBush : MonoBehaviour
{

    private bool _isInteractionAllowed;
    private bool _isEmpty;

    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _isInteractionAllowed = false;
        _isEmpty = false;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isInteractionAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name.Equals("Player") && !_isEmpty)
        {
            _isInteractionAllowed = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name.Equals("Player"))
        {
            _isInteractionAllowed = false;
        }
    }

    private void PickUp()
    {
        _isEmpty = true;
        _isInteractionAllowed = false;
        
        if (spriteRenderer.sprite.name == "bush")
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("Interactable/BerriesBush/bushEmpty");
        }


    }

}

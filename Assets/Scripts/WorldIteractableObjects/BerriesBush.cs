using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerriesBush : Interactable
{
    public Food item;

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
            Interact();
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

    public override void Interact()
    {
        _isEmpty = true;
        _isInteractionAllowed = false;

        bool wasPickedUp = false;
        
        if (spriteRenderer.sprite.name == "bush")
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("Interactable/BerriesBush/bushEmpty");
            wasPickedUp = Inventory.instanse.Add(item);
        }

        if (wasPickedUp)
        {
            SendBushToCooldown();
        }
        else
        {
            
        }
    }

    private void SendBushToCooldown()
    {
        
    }

}

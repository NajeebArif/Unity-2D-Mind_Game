using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiButton : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private string targetMessage;
    public Color highlightColor = Color.cyan;

    private void OnMouseEnter() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
            spriteRenderer.color = highlightColor;
    }

    private void OnMouseExit() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
            spriteRenderer.color = Color.white;
    }

    private void OnMouseDown() {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);   
    }

    private void OnMouseUp() {
        transform.localScale = Vector3.one;
        if (targetObject != null)
            targetObject.SendMessage(targetMessage);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

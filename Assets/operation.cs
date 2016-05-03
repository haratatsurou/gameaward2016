using UnityEngine;
using System;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

[RequireComponent(typeof(Hudcontrol))]
public class operation : MonoBehaviour{
    private Vector3 screenPoint;
    private Vector3 offset;
    public List<Collider> colliders;
    void OnEnable() {
        foreach ( Collider collider in GetComponents<BoxCollider>( ) ) {
            colliders.Add(collider);
        }
    }
    void OnMouseDown() {
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x , Input.mousePosition.y , screenPoint.z));

        colliders[0].isTrigger = true;
        colliders[1].isTrigger = true;
    }

    void OnMouseDrag() {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x , Input.mousePosition.y , screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        transform.position = currentPosition;
    }
    void OnMouseUp() {
        try {
            this.GetComponent<Hudcontrol>( ).Control(this.gameObject);
        } catch (NullReferenceException e ) {
            this.gameObject.AddComponent<Hudcontrol>( );
        }
    }
    

}

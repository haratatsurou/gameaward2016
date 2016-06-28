using UnityEngine;
using System;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;

[RequireComponent(typeof(BoxCollider) , typeof(sortLayer))]
public class operation : MonoBehaviour {
    private Vector3 screenPoint;
    private Vector3 offset;
    public List<Collider> colliders;
    public int arraynum;
    void Awake() {
        arraynum = 0;
        foreach ( Collider collider in GetComponents<Collider>( ) ) {
            colliders.Add(collider);
            collider.isTrigger = true;
            arraynum++;
        }
        this.gameObject.tag = "road";
    }
    void OnMouseDown() {
        if ( !CreateButton.moveflag ) {
            this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x , Input.mousePosition.y , screenPoint.z));

            colliders[0].isTrigger = true;
            colliders[1].isTrigger = true;

        }

        //hubcon.Visibled(false);
    }
    void OnMouseDrag() {
        if ( !CreateButton.moveflag ) {
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x , Input.mousePosition.y , screenPoint.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
            transform.position = currentPosition;

        }
    }
    void OnMouseUp() {
        // hubcon.Control(this.gameObject);
        // hubcon.Visibled(true);
        //GameObject.Find("Main Camera").GetComponent<SetRotation>( ).OnMouseClick( );
    }
    void OnTriggerEnter(Collider col) {
        if ( col.tag == "object" ) {
            CreateButton.colliderobject = true;
        }
    }
    void OnTriggerExit(Collider col) {
        if ( col.tag == "object" ) {
            CreateButton.colliderobject = false;
        }
    }
}

using UnityEngine;
using System;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;

[RequireComponent(typeof(Hudcontrol))]
public class operation : MonoBehaviour{
    private Vector3 screenPoint;
    private Vector3 offset;
    public List<Collider> colliders;
    private Hudcontrol hubcon;

    public bool moveflag = false;
    void OnEnable() {
        foreach ( Collider collider in GetComponents<BoxCollider>( ) ) {
            colliders.Add(collider);
        }
        // try {
        //     hubcon=this.GetComponent<Hudcontrol>( );
        // } catch ( NullReferenceException  ) {
        //     hubcon=this.gameObject.AddComponent<Hudcontrol>( );
        // }
    }
    void OnMouseDown() {
        if ( !moveflag ) {
            this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x , Input.mousePosition.y , screenPoint.z));

            colliders[0].isTrigger = true;
            colliders[1].isTrigger = true;

        
        }

        //hubcon.Visibled(false);
    }
    void OnMouseDrag() {
        if ( !moveflag ) {
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
}

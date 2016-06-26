using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIignoreHit : Button, ICanvasRaycastFilter {
    public bool IsRaycastLocationValid(Vector2 sp , Camera eventCamera) {
        return false;
    }
}
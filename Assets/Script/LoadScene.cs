using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {
    public float loadtime=1.4f;
    public void Load(int loadnum=0) {
       var  button=GameObject.Find("Canvas/" + loadnum).GetComponent<Button>( );
        button.enabled = false;
        FadeManager.Instance.LoadLevel("Stage"+loadnum.ToString(),loadtime);
        this.GetComponent<GraphicRaycaster>( ).enabled = false;
    }
}

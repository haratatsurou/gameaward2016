using UnityEngine;
using System.Collections;

public class CreateButton : MonoBehaviour {
    public GameObject RainDrop;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Create()
    {
        Vector3 inspos = new Vector3(GameObject.Find("2").transform.position.x, GameObject.Find("2").transform.position.y+2, GameObject.Find("2").transform.position.z);
        Instantiate(RainDrop, inspos, Quaternion.identity);
    }
}

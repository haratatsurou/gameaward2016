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
        Vector3 inspos = new Vector3(GameObject.Find("Cube").transform.position.x, GameObject.Find("Cube").transform.position.y+2, GameObject.Find("Cube").transform.position.z);
        Instantiate(RainDrop, inspos, Quaternion.identity);
    }
}

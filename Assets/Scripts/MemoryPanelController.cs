using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[UnityEngine.SerializeField]
public class MemoryPanelController : MonoBehaviour {

    public GameObject prefab;
    public Transform content;

    ListEntryController[] entries;
    
	// Use this for initialization
	void Start () {

        for(int i = 0; i < 25; i++)
        {
            Instantiate(prefab,content);
        }

    }

    // Update is called once per frame
    void Update() {
	}
}

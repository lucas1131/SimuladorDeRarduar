using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[UnityEngine.SerializeField]
public class ListEntryController : MonoBehaviour {

    public Text index;
    public Text value;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setIndex(int newIndex) {
        index.text = newIndex.ToString();
    }

    public void setValue(int newValue) {
        value.text = newValue.ToString();
    }
}

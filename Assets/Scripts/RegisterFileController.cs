using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[UnityEngine.SerializeField]
public class RegisterFileController : MonoBehaviour {

    public Text r0;
    public Text r1;
    public Text r2;
    public Text r3;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setName(string newName)
    {
        nameText.text = newName;
    }

    public void setValues(int[] newValues)
    {
       r0.text = newValues[0].toString();
       r1.text = newValues[1].toString();
       r2.text = newValues[2].toString();
       r3.text = newValues[3].toString();
    }
}

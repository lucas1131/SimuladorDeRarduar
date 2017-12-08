using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[UnityEngine.SerializeField]
public class MemoryPanelController : MonoBehaviour {

    public string memoryName;
    public Text memoryNameText;
    public GameObject prefab;
    public Transform content;

    ListEntryController[] entries = new ListEntryController[25];
    
	// Use this for initialization
	void Start () {

        memoryNameText.text = memoryName;

        for (int i = 0; i < entries.Length; i++)
        {
            GameObject tmp = Instantiate(prefab,content);
            entries[i] = tmp.GetComponent<ListEntryController>();
            entries[i].setIndex(i);
            entries[i].setValue(0);
        }

    }

    // Update is called once per frame
    void Update() {

    }

    void setValue(int index, int value) {
        this.entries[index].setValue(value);
    }

    void setValues(int[] values) {
        for(int i = 0; i < values.Length; i++) {
            this.entries[i].setValue(values[i]);
        }
    }
}

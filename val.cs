using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class val : MonoBehaviour {

    public string type;
    public Text text;

    void Update()
    {
        text.text = PlayerPrefs.GetInt(type) + "";
    }
}

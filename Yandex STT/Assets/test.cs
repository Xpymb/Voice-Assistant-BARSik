using UnityEngine;
using UnityEngine.UI;
using Algorithms;

public class test : MonoBehaviour
{
    public InputField field1;
    public InputField field2;
    public Text textField;
    ParseString ParseString = new ParseString();
    
    /*
    public void UpdateResult()
    {
        string[] str1 = new string[1];
        string str2 = field2.text;
        string result;

        str1[0] = field1.text;

        result = ParseString.FindSubstring(str1, str2) != "" ? "1" : "0";

        textField.text = result;
    }*/
}

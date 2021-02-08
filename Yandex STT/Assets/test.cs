using UnityEngine;
using UnityEngine.UI;
using Algorithms;

public class test : MonoBehaviour
{
    public InputField field1;
    public InputField field2;
    public Text textField;
    public KnuttMorrisPratt KnuttMorrisPratt = new KnuttMorrisPratt();

    public void UpdateResult()
    {
        string str1 = field1.text;
        string str2 = field2.text;
        string result;

        result = KnuttMorrisPratt.FindSubstring(str1, str2).ToString();

        textField.text = result;
    }
}

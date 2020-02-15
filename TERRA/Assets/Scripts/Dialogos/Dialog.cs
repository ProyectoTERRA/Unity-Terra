using UnityEngine;

[System.Serializable]
public class Dialog
{
    public string name;

    [TextArea(3, 100)]
    public string[] sentenceList;
}

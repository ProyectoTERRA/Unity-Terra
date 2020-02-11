using UnityEngine;

[System.Serializable]
public class Dialogue
{

    public string name;

    [TextArea(3, 100)]
    public string[] sentenceList;

}

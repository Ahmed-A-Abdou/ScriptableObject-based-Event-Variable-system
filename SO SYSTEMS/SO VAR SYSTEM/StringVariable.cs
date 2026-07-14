using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Variables/String")]
public class StringVariable : ScriptableVariable
{
    public string Value;
    public string defaultValue;

    public override void ResetValue()
    {
        Value = defaultValue;
    }

    public void SetValue(string val)
    {
        Value = val;
    }
}

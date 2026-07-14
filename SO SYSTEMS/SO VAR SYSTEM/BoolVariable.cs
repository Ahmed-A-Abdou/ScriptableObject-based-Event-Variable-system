using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Variables/Bool")]
public class BoolVariable : ScriptableVariable
{
    public bool Value;
    public bool defaultValue;

    public override void ResetValue()
    {
        Value = defaultValue;
    }

    public void SetValue(bool val)
    {
        Value = val;
    }
}

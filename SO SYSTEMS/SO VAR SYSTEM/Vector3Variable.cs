using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Variables/Vector3")]
public class Vector3Variable : ScriptableVariable
{
    public Vector3 Value;
    public Vector3 defaultValue;

    public override void ResetValue()
    {
        Value = defaultValue;
    }

    public void SetValue(Vector3 val)
    {
        Value = val;
    }
}

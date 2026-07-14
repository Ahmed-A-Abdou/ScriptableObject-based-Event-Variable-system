using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Variables/Float")]
public class FloatVariable : ScriptableVariable
{
    public float Value;
    public float defaultValue;

    public override void ResetValue()
    {
        Value = defaultValue;
    }

    public void SetValue(float val)
    {
        Value = val;
    }
}

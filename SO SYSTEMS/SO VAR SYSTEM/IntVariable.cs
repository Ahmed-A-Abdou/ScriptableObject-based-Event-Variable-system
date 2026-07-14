using UnityEngine;

[System.Serializable]
public class IntReference
{
    public bool useConstant = true;
    public int constantValue;
    public IntVariable variable;

    public int Value
    {
        get => useConstant ? constantValue : variable.Value;
        set
        {
            if (useConstant)
                constantValue = value;
            else
                variable.Value = value;
        }
    }
}

[CreateAssetMenu(menuName = "Scriptable Variables/Int")]
public class IntVariable : ScriptableVariable
{
    public int Value;
    public int defaultValue;

    public override void ResetValue()
    {
        Value = defaultValue;
    }

    public void SetValue(int val)
    {
        Value = val;
    }
}

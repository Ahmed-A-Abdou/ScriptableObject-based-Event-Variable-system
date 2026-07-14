using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Variables/GameObject")]
public class GameObjectVariable : ScriptableVariable
{
    public GameObject Value;
    public GameObject defaultValue;

    public override void ResetValue()
    {
        Value = defaultValue;
    }

    public void SetValue(GameObject val)
    {
        Value = val;
    }
}

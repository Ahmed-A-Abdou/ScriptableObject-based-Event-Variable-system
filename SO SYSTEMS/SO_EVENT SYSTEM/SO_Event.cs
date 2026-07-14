using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO_Event")]
public class SO_Event : ScriptableObject
{
    public List<SOEventListener> listeners = new List<SOEventListener>();

    //raise
    public void Raise()
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventRaised();
        }
    }

    //manage
    public void SubscribeListener(SOEventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void UnSubscribeListener(SOEventListener listener)
    {
         if (listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }

}

using System;
using UnityEngine;
using UnityEngine.Events;
public class SOEventListener : MonoBehaviour
{
    [SerializeField] SO_Event sO_Event;
    public UnityEvent response;

    void OnEnable()
    {
        sO_Event.SubscribeListener(this);
    }

    void OnDisable()
    {
        sO_Event.UnSubscribeListener(this);
    }

    public void OnEventRaised()
    {
        response.Invoke();
    }
}

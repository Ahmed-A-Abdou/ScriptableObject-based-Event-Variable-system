# ScriptableObject Architecture for Unity

A lightweight, asset-driven event and variable system for Unity that eliminates direct script dependencies. Systems communicate through ScriptableObject assets instead of direct references — no singletons, no service locators, no tight coupling.

Inspired by Ryan Hipple's Unite 2017 talk: [Game Architecture with Scriptable Objects](https://www.youtube.com/watch?v=raQ3iHhE_Kk).

## Demo

[![ScriptableObject Architecture Demo](https://img.youtube.com/vi/Mf8WT9wPAm4/0.jpg)](https://www.youtube.com/watch?v=Mf8WT9wPAm4)

## Why This Exists

The standard approach to cross-system communication in Unity usually ends up as one of:
- Direct `GetComponent` references (tight coupling)
- Singleton GameManagers (hidden dependencies, hard to test)
- Static events (can't be wired in the Inspector)

This system routes communication through ScriptableObject assets instead. Any script can raise an event or read a variable without knowing anything about who's listening or who set the value.

## What's Included

### Events

**`SO_Event`** — A ScriptableObject that acts as a game event. Raise it from anywhere. Any number of listeners can subscribe to it.

**`SOEventListener`** — A MonoBehaviour that connects an `SO_Event` asset to a `UnityEvent` in the Inspector. No code required to wire up responses.

```
SO_Event (asset) ←→ SOEventListener (on GameObject) → UnityEvent response
```

### Variables

**`ScriptableVariable`** — Abstract base class for all variable types.

| Type | Asset Menu Path |
|------|----------------|
| `IntVariable` | Scriptable Variables/Int |
| `FloatVariable` | Scriptable Variables/Float |
| `BoolVariable` | Scriptable Variables/Bool |
| `StringVariable` | Scriptable Variables/String |
| `Vector3Variable` | Scriptable Variables/Vector3 |
| `GameObjectVariable` | Scriptable Variables/GameObject |

Each variable holds a runtime `Value` and a `defaultValue` to reset to. Call `ResetValue()` on scene load to restore clean state.

`IntVariable` also ships with an `IntReference` helper that lets scripts choose between a hardcoded constant or a live variable asset — switchable in the Inspector.

## Usage

### Raising an Event

```csharp
[SerializeField] private SO_Event onPlayerDied;

void Die()
{
    onPlayerDied.Raise();
}
```

### Listening to an Event (No Code)

1. Add `SOEventListener` to any GameObject
2. Assign the `SO_Event` asset in the Inspector
3. Wire up the `UnityEvent` response — call any method on any component

### Listening to an Event (In Code)

```csharp
[SerializeField] private SO_Event onPlayerDied;

void OnEnable() => onPlayerDied.SubscribeListener(listener);
void OnDisable() => onPlayerDied.UnSubscribeListener(listener);
```

### Sharing a Variable Between Systems

```csharp
// Writer
[SerializeField] private IntVariable playerHealth;
playerHealth.SetValue(100);

// Reader (different script, no direct reference)
[SerializeField] private IntVariable playerHealth;
Debug.Log(playerHealth.Value);
```

## Project Structure

```
├── Events/
│   ├── SO_Event.cs
│   └── SOEventListener.cs
└── Variables/
    ├── ScriptableVariable.cs
    ├── IntVariable.cs
    ├── FloatVariable.cs
    ├── BoolVariable.cs
    ├── StringVariable.cs
    ├── Vector3Variable.cs
    └── GameObjectVariable.cs
```

## Installation

Copy the `Events/` and `Variables/` folders into your Unity project's `Assets/` directory. No additional setup required.

## Credit

Architecture pattern by **Ryan Hipple** (Schell Games) — [Unite Austin 2017: Game Architecture with Scriptable Objects](https://www.youtube.com/watch?v=raQ3iHhE_Kk).

## Author

**Ahmed Alaa** — Unity Game Developer  
[Portfolio](https://ahmed-a-abdou.github.io) · [GitHub](https://github.com/Ahmed-A-Abdou) · [YouTube](https://www.youtube.com/@AbuAlaa007)

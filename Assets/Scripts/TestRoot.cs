using Core;
using Model;
using UnityEngine;

public class TestRoot : Root
{
    protected override void Awake()
    {
        foreach (var component in GetComponents<IComponent>())
        {
            Connect(component);
        }
        base.Awake();
    }
}
using System;
using UnityEngine;

public class CompNode : MonoBehaviour, IComp
{
    [SerializeField]
    private IComp m_Comp;

    void Awake()
    {
        m_Comp.Init(gameObject);
    }

    #region IComp
    void IInit.Init(GameObject go) => throw new NotSupportedException();
    void IComp.Trigger() => m_Comp.Trigger();
    #endregion
}

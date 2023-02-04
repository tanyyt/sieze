using System;
using UnityEngine;

public class RootNode : MonoBehaviour, IRoot
{
    [SerializeField]
    private IRoot m_Root;

    void Awake()
    {
        m_Root.Init(gameObject);
    }

    #region IRoot
    void IInit.Init(GameObject go) => throw new NotSupportedException();
    bool IRoot.AddComp(IComp comp) => m_Root.AddComp(comp);
    void IRoot.RemoveComp(IComp comp) => m_Root.RemoveComp(comp);
    #endregion
}

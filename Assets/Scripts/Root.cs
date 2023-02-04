using UnityEngine;

public class Root : IRoot
{
    private GameObject m_Go;

    #region IRoot
    void IInit.Init(GameObject go)
    {
        m_Go = go;
    }

    bool IRoot.AddComp(IComp comp)
    {
        return false;
    }

    void IRoot.RemoveComp(IComp comp)
    {

    }
    #endregion
}

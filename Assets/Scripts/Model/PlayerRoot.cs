using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Model
{
    public class PlayerRoot : Root
    {
        protected override void Awake()
        {
            base.Awake();
            Roots.Instance.playerRoot = this;
        }

        void OnDestroy()
        {
            Roots.Instance.playerRoot = null;
        }
    }
}

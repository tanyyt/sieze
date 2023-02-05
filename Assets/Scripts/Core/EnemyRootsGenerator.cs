using System.Collections.Generic;
using Model;
using UnityEngine;

namespace Core
{
    public class EnemyRootsGenerator : EntityGenerator
    {
        public class ComponentData
        {
            public string compName;
            public List<ComponentData> childrenComps;
            public Vector3 localPos;
            public Quaternion localRot;
        }
        public static readonly List<ComponentData> s_WinnerStructure = new List<ComponentData>();
        public static void PutWinnerAsStructure(IRoot root)
        {
            s_WinnerStructure.Clear();
            foreach(var comp in root)
            {
                var compData = new ComponentData();
                compData.compName = comp.GameObject.name.Replace("(Clone)", string.Empty);
                compData.localPos = comp.GameObject.transform.localPosition;
                compData.localRot = comp.GameObject.transform.localRotation;
                if(comp is IConnectorComponent conn)
                {
                    compData.childrenComps = new List<ComponentData>();
                    PutWinnerAsStructure(conn, compData.childrenComps);
                }
                s_WinnerStructure.Add(compData);
            }
        }
        private static void PutWinnerAsStructure(IConnectorComponent conn, List<ComponentData> comps)
        {
            comps.Clear();
            foreach(var comp in conn)
            {
                var compData = new ComponentData();
                compData.compName = comp.GameObject.name.Replace("(Clone)", string.Empty);
                compData.localPos = comp.GameObject.transform.localPosition;
                compData.localRot = comp.GameObject.transform.localRotation;
                if (comp is IConnectorComponent nextConn)
                {
                    compData.childrenComps = new List<ComponentData>();
                    PutWinnerAsStructure(nextConn, compData.childrenComps);
                }
                comps.Add(compData);
            }    
        }
        private static void GenerateCompsViaStructure(IRoot root)
        {
            foreach(var comp in s_WinnerStructure)
            {
                GameObject go = Object.Instantiate(Resources.Load<GameObject>("Prefabs/" + comp.compName), root.GameObject.transform);
                go.transform.localPosition = comp.localPos;
                go.transform.localRotation = comp.localRot;
                var conn = go.GetComponent<IConnectorComponent>();
                if(null != conn)
                {
                    GenerateCompsViaStructure(conn, comp.childrenComps);
                }
            }
        }
        private static void GenerateCompsViaStructure(IConnectorComponent conn, List<ComponentData> comps)
        {
            foreach (var comp in comps)
            {
                GameObject go = Object.Instantiate(Resources.Load<GameObject>("Prefabs/" + comp.compName), conn.GameObject.transform);
                go.transform.localPosition = comp.localPos;
                go.transform.localRotation = comp.localRot;
                var nextConn = go.GetComponent<IConnectorComponent>();
                if (null != nextConn)
                {
                    GenerateCompsViaStructure(nextConn, comp.childrenComps);
                }
            }
        }

        private bool m_HasGenerated = false;

        public EnemyRootsGenerator(Map map) : base(map) { }
        protected override void OnGenerate(Vector2 pos)
        {
            if(m_HasGenerated)
            {
                return;
            }

            Ai ai = null;
            if(s_WinnerStructure.Count == 0)
            {
                ai = Object.Instantiate(Resources.Load<Ai>("Prefabs/AiRoot"), pos, Quaternion.identity);
            }
            else
            {
                ai = Object.Instantiate(Resources.Load<Ai>("Prefabs/EmptyAiRoot"), pos, Quaternion.identity);
                var root = ai.GetComponent<Root>();
                GenerateCompsViaStructure(root);
                root.ConnectCompsInChildren(root, root.GameObject);
            }
            
            ai.Init(Map);
            m_HasGenerated = true;
        }
    }
}
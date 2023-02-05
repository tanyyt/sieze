using Core;
using Model;
using UnityEngine;

public static class GameExtensions
{
    public static void LookAt2D(this Transform transform, Transform target)
    {
        Vector2 direction = target.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    public static IComponent GetNearEntity(this Transform transform, IRoot root)
    {
        var minDis = float.MaxValue;
        IComponent minComponent = null;

        foreach (var component in root)
        {
            var distance = Vector2.Distance(transform.position, component.GameObject.transform.position);
            if (minDis > distance)
            {
                minDis = distance;
                minComponent = component;
            }
        }

        return minComponent;
    }

    public static IRoot FindNearestRoot(this IRoot root, float searchRadius)
    {
        var trans = root.GameObject.transform;
        var minDis = float.MaxValue;
        IRoot minRoot = null;
        foreach (var targetRoot in Roots.Instance)
        {
            if (targetRoot == root)
                continue;
            var distance = Vector2.Distance(trans.position, targetRoot.GameObject.transform.position);
            if (distance < searchRadius && minDis > distance)
            {
                minDis = distance;
                minRoot = targetRoot;
            }
        }

        return minRoot;
    }
}
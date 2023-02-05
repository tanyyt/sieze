using System.Collections;
using Model;
using UnityEngine;

namespace Utils
{
    public static class GameUtils
    {
        public static IEnumerator HurtCoroutine(Renderer renderer, int shaderColorId, IRoot root)
        {
            var curColor = root.Color;
            while (curColor != root.HurtColor)
            {
                curColor = Color.Lerp(curColor, root.HurtColor, Time.deltaTime * 6);
                renderer.material.SetColor(shaderColorId, root.Color);
                yield return null;
            }

            while (curColor != root.Color)
            {
                curColor = Color.Lerp(curColor, root.Color, Time.deltaTime * 6);
                renderer.material.SetColor(shaderColorId, root.Color);
                yield return null;
            }
        }

        public static IEnumerator HurtCoroutine(Renderer[] renderers, int shaderColorId, IRoot root)
        {
            var curColor = root.Color;
            while (curColor != root.HurtColor)
            {
                curColor = Color.Lerp(curColor, root.HurtColor, Time.deltaTime * 6);
                foreach (var renderer in renderers)
                {
                    renderer.material.SetColor(shaderColorId, root.Color);
                }

                yield return null;
            }

            while (curColor != root.Color)
            {
                curColor = Color.Lerp(curColor, root.Color, Time.deltaTime * 6);
                foreach (var renderer in renderers)
                {
                    renderer.material.SetColor(shaderColorId, root.Color);
                }

                yield return null;
            }
        }
    }
}
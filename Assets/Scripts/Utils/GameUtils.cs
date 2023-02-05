using System.Collections;
using Model;
using UnityEngine;

namespace Utils
{
    public static class GameUtils
    {
        private const float transition_time = 25f;
        public static IEnumerator HurtCoroutine(Renderer renderer, int shaderColorId, IRoot root)
        {
            var curColor = root.Color;
            var hurtColor = root.HurtColor;
            while (curColor != root.HurtColor)
            {
                curColor = Color.Lerp(curColor, hurtColor, Time.deltaTime * transition_time);
                renderer.material.SetColor(shaderColorId, curColor);
                yield return null;
            }

            while (curColor != root.Color)
            {
                curColor = Color.Lerp(curColor, root.Color, Time.deltaTime * transition_time/2);
                renderer.material.SetColor(shaderColorId, curColor);
                yield return null;
            }
        }

        public static IEnumerator HurtCoroutine(Renderer[] renderers, int shaderColorId, IRoot root)
        {
            var curColor = root.Color;
            var hurtColor = root.HurtColor;
            while (curColor != root.HurtColor)
            {
                curColor = Color.Lerp(curColor, hurtColor, Time.deltaTime * transition_time);
                foreach (var renderer in renderers)
                {
                    renderer.material.SetColor(shaderColorId, curColor);
                }

                yield return null;
            }

            while (curColor != root.Color)
            {
                curColor = Color.Lerp(curColor, root.Color, Time.deltaTime * transition_time/2);
                foreach (var renderer in renderers)
                {
                    renderer.material.SetColor(shaderColorId, curColor);
                }

                yield return null;
            }
        }
    }
}
using System;

namespace Core
{
    public static class GameEvent
    {
        public static Action<bool> gameOverEvent;
        public static Action cameraHugeShake;
        public static Action cameraShortShake;
    }
}
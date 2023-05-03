using System.Runtime.InteropServices;
using System;
using AOT;

namespace DungeonGames.VKGames
{
    public static class Community
    {
        [DllImport("__Internal")]
        private static extern void JoinDungeonGamesGroup(Action onSuccessCallback, Action onErrorCallback);

        private static Action s_onRewardedCallback;
        private static Action s_onErrorCallback;

        public static void InviteToDungeonGamesGroup(Action onRewardedCallback = null, Action onErrorCallback = null)
        {
            s_onRewardedCallback = onRewardedCallback;
            s_onErrorCallback = onErrorCallback;

            JoinDungeonGamesGroup(OnSuccessCallback, OnErrorCallback);
        }

        [MonoPInvokeCallback(typeof(Action))]
        private static void OnSuccessCallback()
        {
            s_onRewardedCallback?.Invoke();
        }

        [MonoPInvokeCallback(typeof(Action))]
        private static void OnErrorCallback()
        {
            s_onErrorCallback?.Invoke();
        }
    }
}


using Assets.Game.Scripts.Controllers;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Signals
{
    public class InputSignals : MonoBehaviour
    {
        public static InputSignals Instance;

        public Func<AllInputs> onGetAllInputs;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(Instance);
                return;
            }
            Instance = this;
        }
    }
}
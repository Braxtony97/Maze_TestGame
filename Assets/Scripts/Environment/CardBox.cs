using Assets.Scripts.GameMagaer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Environment
{
    public class CardBox
    {
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.CompareTag("Player"))
            {
                EventBus.PlayerHided?.Invoke();
                Debug.Log("Player hided");
            }
        }
    }
}

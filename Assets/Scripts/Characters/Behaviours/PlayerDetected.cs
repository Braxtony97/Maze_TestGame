using Assets.Scripts.GameMagaer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Characters.Behaviours
{
    public class PlayerDetected : MonoBehaviour
    {
        void OnTriggerEnter(Collider collider)
        {
            if (collider.name == "Player")
            {
                EventBus.PlayerDetected?.Invoke();
                Debug.Log("Player detected - attack!");
            }
        }
    }
}

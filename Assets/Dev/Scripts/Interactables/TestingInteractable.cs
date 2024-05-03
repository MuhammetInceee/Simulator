using Simulator.Interfaces;
using UnityEngine;

namespace Simulator.Interactables
{
    public class TestingInteractable : MonoBehaviour, IInteractable
    {
        public void OnClickEvent()
        {
            Debug.Log("How dare you! You cannot interact to me! Fucking asshole! : " + gameObject.name);
        }
    }
}
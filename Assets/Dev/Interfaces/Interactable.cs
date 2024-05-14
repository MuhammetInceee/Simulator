using UnityEngine;

namespace Simulator.Interfaces
{
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] protected GameObject asd;
        internal void OnClickEvent()
        {
            print(asd.name);
        }
    }
}
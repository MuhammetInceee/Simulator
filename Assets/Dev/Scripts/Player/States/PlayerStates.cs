namespace Simulator.Player
{
    public enum PlayerStates
    {
        Move,
        PlacementMode,
        FocusMode,
    }

    [System.Serializable]
    public class PlayerState
    {
        private readonly PlayerStates playerStates;
        private readonly MovementDataHolderSO movementDataHolderSO;
        
        internal PlayerState(PlayerStates playerStates, MovementDataHolderSO movementDataHolderSO)
        {
            this.playerStates = playerStates;
            this.movementDataHolderSO = movementDataHolderSO;
        }
    }
}
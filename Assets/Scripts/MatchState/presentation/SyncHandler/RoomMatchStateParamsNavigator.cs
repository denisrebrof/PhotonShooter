using ExitGames.Client.Photon;
using MatchState.domain.model;
using MatchState.presentation.SyncHandler.model;
using Photon.Pun;

namespace MatchState.presentation.SyncHandler
{
    internal class RoomMatchStateParamsNavigator
    {
        private const string StartStateTimeKey = "StartTime";
        private const string StateKey = "StateKey";

        public RoomMatchStateParams GetStateParams()
        {
            var currentMatchState = (MatchStates) int.Parse(GetRoomCustomProperty(StateKey));
            var startTime = double.Parse(GetRoomCustomProperty(StartStateTimeKey));
            var timeLeft = PhotonNetwork.Time - startTime;
            return new RoomMatchStateParams(currentMatchState, (int) timeLeft);
        }

        public void UpdateStateParams(MatchStates state)
        {
            var customValue = new Hashtable
            {
                {StartStateTimeKey, PhotonNetwork.Time},
                {StateKey, (int) state}
            };
            PhotonNetwork.CurrentRoom.SetCustomProperties(customValue);
        }

        private static string GetRoomCustomProperty(string key) => PhotonNetwork
            .CurrentRoom
            .CustomProperties[key]
            .ToString();
    }
}
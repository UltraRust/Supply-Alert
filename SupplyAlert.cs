namespace Oxide.Plugins
{
    [Info("Supply Alert", "Ultra", "1.1.2")]
    [Description("Sound or visual alert for dropped supply")]

    class SupplyAlert : RustPlugin
    {
        [ChatCommand("g")]
        void RunEffect(BasePlayer player)
        {
            Alert();
        }

        void OnEntitySpawned(BaseEntity baseEntity)
        {

            if (baseEntity != null && baseEntity is SupplyDrop)
            {
                Alert();
            }
        }
       
        void Alert()
        {
            foreach (var player in BasePlayer.activePlayerList)
            {
                SendReply(player, string.Format("<color=#ee2211>{0}</color>", "+++ Supply has dropped +++"));
                Effect.server.Run("assets/bundled/prefabs/fx/invite_notice.prefab", player.transform.position);
            }

        }
    }
}

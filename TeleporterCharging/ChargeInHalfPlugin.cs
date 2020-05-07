using BepInEx;

namespace TeleporterCharging
{
    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin("der10pm.chargeinhalf", "Charge in half", "1.0.0.0")]
    public class ChargeInHalfPlugin : BaseUnityPlugin
    {
        void Awake()
        {
            if (RoR2.Run.instance.stageClearCount > RoR2.Run.stagesPerLoop) {
                On.RoR2.HoldoutZoneController.OnEnable += (orig, self) =>
                {
                    self.baseChargeDuration /= RoR2.Run.instance.stageClearCount / RoR2.Run.stagesPerLoop;
                    orig(self);
                };
            }
        }
    }
}

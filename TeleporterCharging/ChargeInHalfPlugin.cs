using BepInEx;

namespace TeleporterCharging
{
    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin("der10pm.chargeinhalf", "ChargeInHalf", "1.0.1")]
    public class ChargeInHalfPlugin : BaseUnityPlugin
    {
        void Awake()
        {
            On.RoR2.HoldoutZoneController.OnEnable += (orig, self) =>
            {
                self.baseChargeDuration /= (RoR2.Run.instance.stageClearCount + 5) / RoR2.Run.stagesPerLoop;
                orig(self);
            };
        }
    }
}

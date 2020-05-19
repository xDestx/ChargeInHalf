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
                int div = (int)Math.Pow(2, (int)(RoR2.Run.instance.stageClearCount / RoR2.Run.stagesPerLoop));
                self.baseChargeDuration /= div;
                orig(self);
            };
        }
    }
}

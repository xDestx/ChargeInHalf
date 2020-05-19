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
                if(RoR2.run.instance.stageClearCount % RoR2.Run.stagesPerLoop == 0
                    && RoR2.run.instance.stageClearCount > 0) {
                    self.baseChargeDuration /= 2;
                    orig(self);   
                }
            };
        }
    }
}

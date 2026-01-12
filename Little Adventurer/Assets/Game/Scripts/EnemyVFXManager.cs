using UnityEngine;
using UnityEngine.VFX;

public class EnemyVFXManager : MonoBehaviour
{
    public VisualEffect FootStep;
    public VisualEffect AttackVFX;
    public VisualEffect BeingHitSplashVFX;
    public ParticleSystem BeingHitVFX;
    public void PlayAttackVFX()
    {
        AttackVFX.SendEvent("OnPlay");
    }

    public void BurstFootStep()
    {
        FootStep.SendEvent("OnPlay");
    }

    public void PlayBeingHitVFX(Vector3 attackerPos)
    {
        if (BeingHitVFX != null)
        {
            Vector3 forceForward = transform.position - attackerPos;
            forceForward.Normalize();
            forceForward.y = 0;

            // BeingHitVFXをインスタンス化
            ParticleSystem instantiatedVFX = Instantiate(BeingHitVFX, transform.position, Quaternion.LookRotation(forceForward));

            // インスタンスを再生
            instantiatedVFX.Play();

            // 一定時間後に自動削除（オプション）
            Destroy(instantiatedVFX.gameObject, instantiatedVFX.main.duration + instantiatedVFX.main.startLifetime.constantMax);

            Vector3 splashPos = transform.position;
            splashPos.y += 2f;
            VisualEffect newSplashVFX = Instantiate(BeingHitSplashVFX, splashPos, Quaternion.identity);
            newSplashVFX.SendEvent("OnPlay");
            Destroy(newSplashVFX.gameObject, 10f); // 10秒後に削除
        }
    }
}

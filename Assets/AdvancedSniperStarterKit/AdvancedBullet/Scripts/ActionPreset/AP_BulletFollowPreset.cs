using UnityEngine;
using System.Collections;

public class AP_BulletFollowPreset : AS_ActionPreset
{

	public override void Shoot (GameObject bullet)
	{
		if (!ActionCam) {
			return;	
		}

		ActionCam.InAction = false;
		ActionCam.ObjectLookAt = bullet;
		ActionCam.ObjectFollowing = bullet;
		ActionCam.SetPosition (bullet.transform.position - bullet.transform.forward, false);
		base.Shoot (bullet);
	}
	
	public override void FirstDetected (AS_Bullet bullet, AS_BulletHiter target,Vector3 point)
	{
		if (!ActionCam) {
			return;	
		}
		
		if (!ActionCam.InAction) {
			//Debug.Log ("First Detect target : " + target.gameObject.name);
			ActionCam.ObjectLookAt = bullet.gameObject;
			ActionCam.ObjectFollowing = bullet.gameObject;
			ActionCam.Follow = true;
			ActionCam.SetPosition (bullet.transform.position + (bullet.transform.right) - bullet.transform.forward * 2, false);
			ActionCam.ActionBullet (10.0f);
			ActionCam.SlowmotionNow (0.1f, 10.0f);
		}
		
		
		base.FirstDetected (bullet, target, point);
	}
	
	public override void TargetDetected (AS_Bullet bullet, AS_BulletHiter target,Vector3 point)
	{
		
		if (!ActionCam) {
			return;	
		}
		if (!ActionCam.HitTarget) {
			ActionCam.ObjectLookAt = bullet.gameObject;
			ActionCam.ObjectFollowing = bullet.gameObject;
			ActionCam.ActionBullet (10.0f);
			ActionCam.SlowmotionNow (0.01f, 10.0f);
			ActionCam.Follow = true;
			ActionCam.LengthOffset = -(ActionCam.Length-1);
			ActionCam.SetPosition (bullet.transform.position + (bullet.transform.right) - bullet.transform.forward, ActionCam.Detected);
		}
		base.TargetDetected (bullet, target, point);
	}
	
	public override void TargetHited (AS_Bullet bullet, AS_BulletHiter target,Vector3 point)
	{
		if (!ActionCam) {
			return;	
		}
		
		ActionCam.Follow = false;
		ActionCam.ObjectFollowing = target.gameObject;
		ActionCam.ObjectLookAt = target.gameObject;
		ActionCam.ActionBullet (3.0f);
		ActionCam.Slowmotion (0.05f, 3.2f);
		ActionCam.SetPosition (point + (bullet.transform.right * 2),ActionCam.Detected);
		
		
		base.TargetHited (bullet, target, point);
		
	}
}

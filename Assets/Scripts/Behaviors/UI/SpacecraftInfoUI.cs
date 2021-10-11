using UnityEngine;
using UnityEngine.UI;

public class SpacecraftInfoUI : MonoBehaviour
{
    [Header("UI containers")]
    public GameObject InfoUIContainer;
    public Text SpacecraftCoordinates;
    public Text SpacecraftRotationAngle;
    public Text SpacecraftInstantSpeed;
    public Text LaserCharges;
    public Text LaserCooldown;
    public Text LaserRechargeTime;

    [Header("Other")]
    public SpacecraftPositionTracker SpacecraftPositionTracker;
    public LaserInfoTracker LaserInfoTracker;
    public PlayerEvents PlayerEvents;

    private void Start()
    {
        PlayerEvents.PlayerDied += Hide;
        Open();
    }

    private void Open()
    {
        InfoUIContainer.SetActive(true);
    }

    private void Hide()
    {
        InfoUIContainer.SetActive(false);
    }

    private void Update()
    {
        UpdateSpacecraftCoordinates();
        UpdateSpacecraftRotationAngle();
        UpdateSpacecraftInstantSpeed();
        UpdateLaserCharges();
        UpdateLaserCooldownTime();
        UpdateLaserRechargeTime();
    }

    private void UpdateSpacecraftCoordinates()
    {
        Vector3 position = SpacecraftPositionTracker.Position;
        SpacecraftCoordinates.text = $"{position.x.ToString("0.000")}, {position.y.ToString("0.000")}";
    }

    private void UpdateSpacecraftRotationAngle()
    {
        SpacecraftRotationAngle.text = SpacecraftPositionTracker.Rotation.eulerAngles.z.ToString("0.00");
    }

    private void UpdateSpacecraftInstantSpeed()
    {
        Vector3 instantSpeed = SpacecraftPositionTracker.InstantSpeed;
        SpacecraftInstantSpeed.text = $"{instantSpeed.x.ToString("0.000")}, {instantSpeed.y.ToString("0.000")}";
    }

    private void UpdateLaserCharges()
    {
        LaserCharges.text = LaserInfoTracker.Charges.ToString("0"); 
    }

    private void UpdateLaserCooldownTime()
    {
        LaserCooldown.text = LaserInfoTracker.CooldownTime.ToString("0.00");
    }

    private void UpdateLaserRechargeTime()
    {
        LaserRechargeTime.text = LaserInfoTracker.RechargeTime.ToString("0.00");
    }

    private void OnDestroy()
    {
        PlayerEvents.PlayerDied -= Hide;
    }
}

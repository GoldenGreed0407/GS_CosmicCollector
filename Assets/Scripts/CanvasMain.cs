using UnityEngine;
using UnityEngine.UI;

public class CanvasMain : MonoBehaviour
{
    [SerializeField] public Text textCollectableCount;
    [SerializeField] public Text textDeposited;
    [SerializeField] public Text textShipLife;
    [SerializeField] public Text textStationLife;
    [SerializeField] public Text textAmmo;

    private void Start()
    {
        CanvasStats.collectable = 0;
        CanvasStats.deposited = 0;
        CanvasStats.shipLife = 3;
        CanvasStats.StationLife = 100;
        CanvasStats.Ammo = 10;
        UpdateShipLife();
        UpdateStationLife();
        UpdateAmmo();
    }
    public void UpdateCollectable()
    {
        textCollectableCount.text = CanvasStats.collectable.ToString();
    }
    public void UpdateShipLife()
    {
        textShipLife.text = CanvasStats.shipLife.ToString();
    }
    public void UpdateStationLife()
    {
        textStationLife.text = CanvasStats.StationLife.ToString();
    }
    public void UpdateAmmo()
    {
        textAmmo.text = CanvasStats.Ammo.ToString();
    }
    public void UpdateDeposited()
    {
        textDeposited.text = CanvasStats.deposited.ToString();
    }
}

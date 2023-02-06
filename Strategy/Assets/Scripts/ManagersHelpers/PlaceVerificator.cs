public class PlaceVerificator
{
    private GroundElement _ground;
    private Building _building;
    public bool StartVeifi(GroundElement ground, Building building)
    {
        _ground = ground;
        _building = building;

        if (!VerifiCompatiblity()) return false;
        if (!VerifiGroundOnBusy()) return false;
        if (!VerifiCost()) return false;
        return true;
    }

    private bool VerifiCompatiblity()
    {
        if (_ground.gameObject.layer == 6 && _building.type == TypeBuildings.floatBuilding)
            return false;
        if (_ground.gameObject.layer == 4 && _building.type == TypeBuildings.groundBuilding)
            return false;

        return true;
    }

    private bool VerifiGroundOnBusy()
    {
        if (_ground.Busy)
            return false;
        return true;
    }

    private bool VerifiCost()
    {
        return Bank.instance.CheckCost(_building.config.buildingLevels[_building.level - 1]);
    }
}

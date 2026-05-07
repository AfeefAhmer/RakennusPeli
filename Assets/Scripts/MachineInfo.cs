using UnityEngine;
using System;

public enum Rakennus
{
    Kerrostalo,
    Myyntiautomaatti,
    Omakotitalo,
    Kauppa
}

public enum Auto
{
    musta,
    punainen,
    miniautoPunainen
}

public enum MachineType
{
    BuildingMachine,
    CarMachine
}

public class MachineInfo : MonoBehaviour
{
    [Header("Basic Info")]
    public string merchantName;
    public MachineType machineType;

    // ================= RAKENNUKSEN HINTA =================
    public int GetBuildingPrice(int rakennusIndex)
    {
        Rakennus rakennus = (Rakennus)rakennusIndex;

        switch (rakennus)
        {
            case Rakennus.Kerrostalo: return 5000;
            case Rakennus.Myyntiautomaatti: return 2000;
            case Rakennus.Omakotitalo: return 2500;
            case Rakennus.Kauppa: return 10000;
        }

        return 0;
    }

    // ================= RAKENNUKSEN TUOTTO (esim peliin) =================
    public int GetBuildingIncome(int rakennusIndex)
    {
        Rakennus rakennus = (Rakennus)rakennusIndex;

        switch (rakennus)
        {
            case Rakennus.Kerrostalo: return 5000;
            case Rakennus.Myyntiautomaatti: return 50;
            case Rakennus.Omakotitalo: return 2000;
            case Rakennus.Kauppa: return 3000;
        }

        return 0;
    }

    // ================= AUTON HINTA =================
    public int GetCarPrice(int autoIndex)
    {
        Auto auto = (Auto)autoIndex;

        switch (auto)
        {
            case Auto.musta: return 2000;
            case Auto.punainen: return 2500;
            case Auto.miniautoPunainen: return 1000;
        }

        return 0;
    }

    // ================= AUTON NOPEUS =================
    public int GetCarSpeed(int autoIndex)
    {
        Auto auto = (Auto)autoIndex;

        switch (auto)
        {
            case Auto.musta: return 180;
            case Auto.punainen: return 200;
            case Auto.miniautoPunainen: return 120;
        }

        return 0;
    }

    // ================= ENUM NIMET UI:ta varten =================
    public string[] GetRakennusNames() => Enum.GetNames(typeof(Rakennus));
    public string[] GetAutoNames() => Enum.GetNames(typeof(Auto));
}
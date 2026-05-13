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
    sininen
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
            case Rakennus.Kerrostalo: return 500;
            case Rakennus.Myyntiautomaatti: return 20;
            case Rakennus.Omakotitalo: return 250;
            case Rakennus.Kauppa: return 100;
        }

        return 0;
    }

    // ================= RAKENNUKSEN TUOTTO (esim peliin) =================
    public int GetBuildingIncome(int rakennusIndex)
    {
        Rakennus rakennus = (Rakennus)rakennusIndex;

        switch (rakennus)
        {
            case Rakennus.Kerrostalo: return 500;
            case Rakennus.Myyntiautomaatti: return 50;
            case Rakennus.Omakotitalo: return 200;
            case Rakennus.Kauppa: return 300;
        }

        return 0;
    }

    // ================= AUTON HINTA =================
    public int GetCarPrice(int autoIndex)
    {
        Auto auto = (Auto)autoIndex;

        switch (auto)
        {
            case Auto.musta: return 20;
            case Auto.punainen: return 25;
            case Auto.sininen: return 30;
        }

        return 0;
    }

    // ================= AUTON NOPEUS =================
    public int GetCarSpeed(int autoIndex)
    {
        Auto auto = (Auto)autoIndex;

        switch (auto)
        {
            case Auto.musta: return 20;
            case Auto.punainen: return 20;
            case Auto.sininen: return 20;
        }

        return 0;
    }

    // ================= ENUM NIMET UI:ta varten =================
    public string[] GetRakennusNames() => Enum.GetNames(typeof(Rakennus));
    public string[] GetAutoNames() => Enum.GetNames(typeof(Auto));
}
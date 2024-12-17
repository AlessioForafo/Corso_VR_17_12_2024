#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.WebUI;
using FTOptix.Recipe;
using FTOptix.DataLogger;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.OPCUAServer;
using FTOptix.Retentivity;
using FTOptix.CoreBase;
using FTOptix.Core;
using FTOptix.Alarm;
#endregion

public class DesignTimeNetLogic1 : BaseNetLogic
{
    [ExportMethod]
    public void MioPrimoMetodo()
    {
        // Insert code to be executed by the method
        var mioTesto = LogicObject.GetVariable("Testo");
        Log.Info(mioTesto.Value);
        
    }

    [ExportMethod]
    public void MioSecondoMetodo()
    {
        // Insert code to be executed by the method
        var mioAllarme = InformationModel.Make<DigitalAlarm>("AllarmeCodice");
        mioAllarme.Message = "Testo allarme prova";
        mioAllarme.Severity = 10;
        Project.Current.Get("Alarms").Add(mioAllarme);
    }
}

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

public class RuntimeNetLogic1 : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        Log.Info("Progetto avviato!");
        myPeriodicTask = new PeriodicTask(IncrementVariable, 1000, LogicObject);
        myPeriodicTask.Start();
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
        Log.Info("Progetto arrestato!");
        myPeriodicTask.Dispose();
    }

    [ExportMethod]
    public void MioMetodo()
    {
        Log.Info("Mio metodo!");
    }
    private void IncrementVariable()
    {
        var variable1 = Project.Current.GetVariable("Model/Incremento");
        variable1.Value = variable1.Value + 1;
    }

    private PeriodicTask myPeriodicTask;
}

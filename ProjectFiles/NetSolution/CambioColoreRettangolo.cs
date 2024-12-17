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

public class CambioColoreRettangolo : BaseNetLogic
{
    private IUAVariable variable1;

    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        variable1 = Project.Current.GetVariable("Model/Incremento");
        variable1.VariableChange += Variable1_VariableChange;
    }

    private void Variable1_VariableChange(object sender, VariableChangeEventArgs e)
    {
        var mioRettangolo = (Rectangle)Owner;
        if (e.NewValue > 20)
            mioRettangolo.FillColor = Colors.Red;
        else
            mioRettangolo.FillColor = Colors.Yellow;
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
        variable1.VariableChange -= Variable1_VariableChange;
    }
}

using Login1.Utilidades;


namespace Login1.Vistas;

public partial class Status : ContentPage
{
    public Status()
    {
        InitializeComponent();
        updateStatus();
    }

    public void updateStatus()
    {
        if (StatusCheck.status == "Health endpoint down!!")
        {
            circle.Color = Color.FromRgb(255, 0, 0);
            statuss.Text = StatusCheck.status;
        }
        else if (StatusCheck.status == "All the endpoints are working fine!")
        {
            circle.Color = Color.FromRgb(0, 255, 0);
            statuss.Text = StatusCheck.status;
        }
        else
        {
            circle.Color = Color.FromRgb(255, 255, 0);
            statuss.Text = StatusCheck.status;
        }
    }
}
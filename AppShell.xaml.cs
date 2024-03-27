using Login1.Vistas;

namespace Login1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Desechables), typeof(Desechables));
        }
    }
}

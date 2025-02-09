using System.Windows;

namespace trabajoFinalInterfaces
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MostrarUsuarios(object sender, RoutedEventArgs e) //aunque ponga mostrar usuarios, es como el login
        {
            string nombre = txtNombre.Text.Trim();
            string contraseña = txtContraseña.Password.Trim();

            if (BaseDeDatos.Login(nombre, contraseña))
            {
                Main ventanaPrincipal = new Main();
                ventanaPrincipal.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}

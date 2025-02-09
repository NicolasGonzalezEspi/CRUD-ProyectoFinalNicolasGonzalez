using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace trabajoFinalInterfaces
{
    public partial class Borrar : Page
    {
        public Borrar()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void CargarProductos()
        {
            DataTable productos = BaseDeDatos.MostrarProductos();
            dgProductos.ItemsSource = productos.DefaultView;
        }

        private void BtnBorrar_Click(object sender, RoutedEventArgs e)
        {
            string nombreProducto = txtProductoBorrar.Text.Trim();

            // Si no se ingresó texto, obtenerlo del producto seleccionado en el DataGrid
            if (string.IsNullOrEmpty(nombreProducto) && dgProductos.SelectedItem != null)
            {
                DataRowView filaSeleccionada = (DataRowView)dgProductos.SelectedItem;
                nombreProducto = filaSeleccionada["Producto"].ToString();
            }

            // Si aún no hay producto, no hacer nada
            if (string.IsNullOrEmpty(nombreProducto)) return;

            MessageBoxResult confirmacion = MessageBox.Show($"¿Está seguro de que desea borrar \"{nombreProducto}\"?",
                                                            "Confirmar eliminación",
                                                            MessageBoxButton.YesNo,
                                                            MessageBoxImage.Warning);

            if (confirmacion == MessageBoxResult.Yes)
            {
                bool eliminado = BaseDeDatos.BorrarProducto(nombreProducto);
                if (eliminado)
                {
                    MessageBox.Show("Producto eliminado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarProductos();
                    txtProductoBorrar.Clear();
                }
                else
                {
                    MessageBox.Show("No se encontró el producto o no pudo ser eliminado.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void dgProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Si se selecciona un producto, mostrar su nombre en el TextBox
            if (dgProductos.SelectedItem != null)
            {
                DataRowView filaSeleccionada = (DataRowView)dgProductos.SelectedItem;
                txtProductoBorrar.Text = filaSeleccionada["Producto"].ToString();
            }
        }
    }
}

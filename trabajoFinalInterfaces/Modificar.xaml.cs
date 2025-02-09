using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace trabajoFinalInterfaces
{
    public partial class Modificar : Page
    {
        public Modificar()
        {
            InitializeComponent();
            CargarCategorias();
            CargarProductos();
        }

        private void CargarCategorias()
        {
            DataTable categorias = BaseDeDatos.ObtenerCategorias();
            cbCategorias.ItemsSource = categorias.DefaultView;
            cbCategorias.DisplayMemberPath = "Categoría"; // Nombre visible
            cbCategorias.SelectedValuePath = "ID"; // Valor real (CategoryID)
        }

        private void CargarProductos()
        {
            DataTable productos = BaseDeDatos.MostrarProductos();
            dgProductos.ItemsSource = productos.DefaultView;
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            string productoAntiguo = txtProductoAntiguo.Text.Trim();
            string productoNuevo = txtProductoNuevo.Text.Trim();
            if (string.IsNullOrEmpty(productoAntiguo) || string.IsNullOrEmpty(productoNuevo) || cbCategorias.SelectedValue == null)
            {
                MessageBox.Show("Ingrese un nombre válido y seleccione una categoría.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int idCategoria = Convert.ToInt32(cbCategorias.SelectedValue);
            bool modificado = BaseDeDatos.ModificarProducto(productoAntiguo, productoNuevo, idCategoria);
            if (modificado)
            {
                MessageBox.Show("Producto modificado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                CargarProductos();
                txtProductoAntiguo.Clear();
                txtProductoNuevo.Clear();
                cbCategorias.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Error al modificar el producto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

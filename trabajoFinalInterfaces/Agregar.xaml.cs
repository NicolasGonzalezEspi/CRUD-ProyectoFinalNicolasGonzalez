using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace trabajoFinalInterfaces
{
    public partial class Agregar : Page
    {
        public Agregar()
        {
            InitializeComponent();
            CargarCategorias();
            CargarProductos();
        }

        private void CargarCategorias()
        {
            DataTable categorias = BaseDeDatos.ObtenerCategorias();
            cbCategorias.ItemsSource = categorias.DefaultView;
            cbCategorias.DisplayMemberPath = "Categoría"; // Nombre a mostrar
            cbCategorias.SelectedValuePath = "ID"; // Valor real (CategoryID)
        }

        private void CargarProductos()
        {
            DataTable productos = BaseDeDatos.MostrarProductos();
            dgProductos.ItemsSource = productos.DefaultView;
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            string nombreProducto = txtProducto.Text.Trim();
            if (string.IsNullOrEmpty(nombreProducto) || cbCategorias.SelectedValue == null)
            {
                MessageBox.Show("Por favor, ingrese un nombre y seleccione una categoría.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int idCategoria = Convert.ToInt32(cbCategorias.SelectedValue);

            bool agregado = BaseDeDatos.AgregarProducto(nombreProducto, idCategoria);
            if (agregado)
            {
                MessageBox.Show("Producto agregado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                CargarProductos();
                txtProducto.Clear();
                cbCategorias.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Error al agregar el producto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

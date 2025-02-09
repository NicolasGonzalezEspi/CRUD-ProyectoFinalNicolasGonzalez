using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace trabajoFinalInterfaces
{
    public partial class Inicio : Page
    {
        public Inicio()
        {
            InitializeComponent();
            CargarProductos();  //al iniciarse esta página, se muestran todos los productos y sus respectivas categorías
            //además, siempre que se haga una opción tipo crud, se llamará a este método para que se vea reflejado automáticamente.
        }

        private void CargarProductos()
        {
            DataTable productos = BaseDeDatos.MostrarProductos(); // llamada a la función determinada de  baseDeDatos
            dgProductos.ItemsSource = productos.DefaultView; //volcamos los datos al datagrid (la tabla)
        }



    }
}

using System;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace trabajoFinalInterfaces
{
    internal class BaseDeDatos
    {
        private static readonly string cadenaConexion =
            "server=localhost;port=3306;user=root;password=root;database=northwind;";
        private static MySqlConnection conexion = null;

        public static bool Conectar()
        {
            try
            {
                if (conexion == null)
                {
                    conexion = new MySqlConnection(cadenaConexion);
                }
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }




        public static void Desconectar()
        {
            if (conexion != null)
            {
                conexion.Close();
                conexion = null;
            }
        }

        public static bool Login(string usuario, string contrasena)
        {
            bool existe = false;
            string consultaUser = "SELECT * FROM usuarios WHERE usuario = @usuario AND contraseña = @contrasena";

            if (conexion == null || conexion.State != ConnectionState.Open)
            {
                if (!Conectar()) return false;
            }

            using (MySqlCommand cmd = new MySqlCommand(consultaUser, conexion))
            {
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);

                using (MySqlDataReader lector = cmd.ExecuteReader())
                {
                    if (lector.Read()) existe = true;
                }
            }

            return existe;
        }

        public static DataTable MostrarProductos()
        {
            string consulta = @"SELECT p.ProductName AS 'Producto', c.CategoryName AS 'Categoría' 
                                FROM products p 
                                JOIN categories c ON p.CategoryID = c.CategoryID";

            DataTable tabla = new DataTable();

            if (conexion == null || conexion.State != ConnectionState.Open)
            {
                if (!Conectar()) return tabla;
            }

            using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
            {
                using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                {
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }

        public static DataTable ObtenerCategorias()
        {
            string consulta = "SELECT CategoryID AS 'ID', CategoryName AS 'Categoría' FROM categories";
            DataTable categorias = new DataTable();

            if (conexion == null || conexion.State != ConnectionState.Open)
            {
                if (!Conectar()) return categorias;
            }

            using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
            {
                using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                {
                    adaptador.Fill(categorias);
                }
            }

            return categorias;
        }

        public static bool AgregarProducto(string nombreProducto, int idCategoria)
        {
            string consulta = "INSERT INTO products (ProductName, CategoryID) VALUES (@nombre, @categoria)";

            if (conexion == null || conexion.State != ConnectionState.Open)
            {
                if (!Conectar()) return false;
            }

            using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
            {
                cmd.Parameters.AddWithValue("@nombre", nombreProducto);
                cmd.Parameters.AddWithValue("@categoria", idCategoria);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public static bool ModificarProducto(string productoAntiguo, string productoNuevo, int idCategoria)
        {
            string consulta = "UPDATE products SET ProductName = @productoNuevo, CategoryID = @idCategoria WHERE ProductName = @productoAntiguo";

            if (conexion == null || conexion.State != ConnectionState.Open)
            {
                if (!Conectar()) return false;
            }

            using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
            {
                cmd.Parameters.AddWithValue("@productoNuevo", productoNuevo);
                cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                cmd.Parameters.AddWithValue("@productoAntiguo", productoAntiguo);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }
        public static bool BorrarProducto(string nombreProducto)
        {
            if (conexion == null || conexion.State != ConnectionState.Open)
            {
                if (!Conectar()) return false;
            }

            // Obtener el ID del producto basado en el nombre
            string obtenerIdQuery = "SELECT ProductID FROM products WHERE ProductName = @nombreProducto";
            int productId;

            using (MySqlCommand cmd = new MySqlCommand(obtenerIdQuery, conexion))
            {
                cmd.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                object result = cmd.ExecuteScalar();

                if (result == null) return false; // Producto no encontrado

                productId = Convert.ToInt32(result);
            }

            // Eliminar referencias en orderdetails
            string eliminarDetallesQuery = "DELETE FROM orderdetails WHERE ProductID = @productId";
            using (MySqlCommand cmd = new MySqlCommand(eliminarDetallesQuery, conexion))
            {
                cmd.Parameters.AddWithValue("@productId", productId);
                cmd.ExecuteNonQuery();
            }

            // Ahora eliminar el producto
            string eliminarProductoQuery = "DELETE FROM products WHERE ProductID = @productId";
            using (MySqlCommand cmd = new MySqlCommand(eliminarProductoQuery, conexion))
            {
                cmd.Parameters.AddWithValue("@productId", productId);
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

    }
}
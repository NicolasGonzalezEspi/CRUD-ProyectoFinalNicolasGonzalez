# WPF Northwind CRUD

## 📌 Índice
1. [Descripción](#-descripción)
2. [Características principales](#-características-principales)
3. [Tecnologías Utilizadas](#-tecnologías-utilizadas)
4. [Interfaz de Usuario](#-interfaz-de-usuario)
5. [Instalación y Configuración](#-instalación-y-configuración)
   - [Requisitos previos](#1️⃣-requisitos-previos)
   - [Configuración de la base de datos](#2️⃣-configuración-de-la-base-de-datos)
   - [Ejecutar el Proyecto](#3️⃣-ejecutar-el-proyecto)
6. [Funcionalidades](#-funcionalidades)
7. [Contacto](#-contacto)
8. [Licencia](#-licencia)

## 📌 Descripción
WPF Northwind CRUD es una aplicación de escritorio desarrollada en WPF y C# que permite la gestión de productos de la base de datos Northwind. Implementa un CRUD completo (Crear, Leer, Actualizar y Eliminar) con una interfaz moderna y funcional.

## 🚀 Características principales
- Autenticación de usuarios.
- Conexión segura con MySQL.
- Interfaz gráfica atractiva y fácil de usar.
- Funcionalidad de agregar, modificar y eliminar productos.
- Gestión de categorías.
- Uso de DataGrid para visualización de datos en tiempo real.

## 🛠️ Tecnologías Utilizadas
- C# con .NET WPF
- MySQL para la base de datos
- XAML para la interfaz gráfica

## 🎨 Interfaz de Usuario
El diseño de la interfaz sigue un esquema visual moderno con colores oscuros y verdes, siguiendo buenas prácticas de UX/UI.

## 📌 Instalación y Configuración
### 1️⃣ Requisitos previos
- Visual Studio 2019 o superior
- MySQL Server y MySQL Workbench
- .NET 5.0 o superior

### 2️⃣ Configuración de la base de datos
1. Crear la base de datos `northwind` en MySQL.
2. Importar los datos de ejemplo en la base de datos.
3. Configurar la cadena de conexión en `BaseDeDatos.cs`:
   ```csharp
   private static readonly string cadenaConexion =
       "server=localhost;port=3306;user=root;password=root;database=northwind;";
   ```

### 3️⃣ Ejecutar el Proyecto
1. Abrir el proyecto en Visual Studio.
2. Compilar y ejecutar la aplicación.
3. Iniciar sesión y gestionar productos.

## 📜 Funcionalidades
- **Autenticación:** Inicio de sesión seguro con validación de credenciales.
- **Visualización de productos:** Uso de DataGrid para mostrar información.
- **Agregar productos:** Formulario para añadir nuevos productos con categoría.
- **Modificar productos:** Edición de productos existentes.
- **Eliminar productos:** Opción para eliminar productos de la base de datos.

## 📧 Contacto
**Autor:** Nicolás González  
✉️ Email: [nicolascmyr@gmail.com](mailto:nicolascmyr@gmail.com)  
📌 Proyecto desarrollado como trabajo final de interfaces gráficas.

## 📜 Licencia
Este proyecto se distribuye bajo la licencia MIT. Puedes ver más detalles en el archivo LICENSE.


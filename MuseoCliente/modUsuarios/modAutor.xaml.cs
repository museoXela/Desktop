﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MuseoCliente
{
	/// <summary>
	/// Lógica de interacción para modAutor.xaml
	/// </summary>
	public partial class modAutor : UserControl
	{
        Connection.Objects.Autor autor = new Connection.Objects.Autor();
        Connection.Objects.Pais paises = new Connection.Objects.Pais();
        public modAutor()
		{
			this.InitializeComponent();
            cmbPais.DisplayMemberPath = "name";
            cmbPais.SelectedValuePath = "iso";
            cmbPais.ItemsSource = paises.todosPaises();
		}

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            autor.nombre = txtNombre.Text;
            autor.apellido = txtApellido.Text;
            autor.pais = cmbPais.SelectedValue.ToString();
            MessageBox.Show(cmbPais.SelectedValue.ToString());
        }
	}
}
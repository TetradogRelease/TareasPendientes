﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tareas_Pendientes_v2
{
    /// <summary>
    /// Lógica de interacción para ModificarNombreCategorias.xaml
    /// </summary>
    public partial class ModificarNombreCategorias : Window
    {
        public ModificarNombreCategorias()
        {
            TextBox txtCategoria;
            String[] categorias;
            InitializeComponent();
            categorias = Lista.TodasLasCategorias();
            for(int i=0;i<categorias.Length;i++)
            {
                txtCategoria = new TextBox();
                txtCategoria.Text = categorias[i];
                txtCategoria.Tag = categorias[i];//es la version sin modificar y que se remplaza cuando se aplica
                //no hay un evento para saber si esta acabdo de editar sino lo pondria y quitaria el boton   
                if (txtCategoria.Text == MainWindow.TODASLASLISTAS)
                    txtCategoria.IsReadOnly = true;//asi no lo modifican :)
                stkCategorias.Children.Add(txtCategoria);

            }

            
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //comprueba que sean diferentes y luego lo aplica, sino avisa
            SortedList<string, TextBox> listaDeCategorias = new SortedList<string, TextBox>();
            string categoria;
            TextBox txtBxCategoria;
            try {
                for (int i = 0; i < stkCategorias.Children.Count; i++) {
                    txtBxCategoria =(TextBox)stkCategorias.Children[i];
                    categoria = txtBxCategoria.Text;
                    listaDeCategorias.Add(categoria, txtBxCategoria);

                }
                foreach(KeyValuePair<string,TextBox> txtCategoria in listaDeCategorias)
                {
                    Lista.CambiarNombreCategoria(txtCategoria.Value.Tag as string, txtCategoria.Key);
                    txtCategoria.Value.Tag = txtCategoria.Key;
                }
                MessageBox.Show("Se ha guardado correctamente","Faena guardada",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Hay categorias con el mismo nombre","No se ha podido guardar",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
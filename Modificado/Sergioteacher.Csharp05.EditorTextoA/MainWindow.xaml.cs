using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace Sergioteacher.Csharp05.EditorTextoA
{
    public partial class MainWindow : Window
    {
        private static String tituloA = "EditorTextoA";
        private static String fpath;
        bool modificado;

        public MainWindow()
        {
            InitializeComponent();
            this.Title = tituloA;
            fpath = "";
            modificado = false;
        }

        private void Acercade_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Un editor, con un control básico de edición \n " +
                "mostrando:\n" +
                "   -Un menú con `Command´ \n" +
                "   -y facilidades de fichero con Win32" +
                "\n" +
                "\n" +
                "             Copyright (C) Sergioteacher", "Edidor básico");
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Ventana1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (modificado)
            {
                MessageBoxResult resultado = MessageBox.Show("Se ha modificado, ¿Guardar?", "Duda...", MessageBoxButton.YesNo);
                switch (resultado)
                {
                    case MessageBoxResult.Yes:
                        try
                        {
                            if (fpath == "")
                            {
                                string rutaArchivo = InputBox("Guardar archivo como", "Ingresa la ruta del archivo:", "archivo.txt");
                                if (!string.IsNullOrEmpty(rutaArchivo))
                                {
                                    File.WriteAllText(rutaArchivo, Tedit.Text);
                                    modificado = false;
                                    fpath = rutaArchivo;
                                    Ventana1.Title = tituloA + " " + fpath;
                                }
                                else
                                {
                                    MessageBox.Show(" Cancelado ", "Na de na", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                }
                            }
                            else
                            {
                                File.WriteAllText(fpath, Tedit.Text);
                                modificado = false;
                                Ventana1.Title = tituloA + " " + fpath;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    case MessageBoxResult.No:
                        MessageBox.Show("Se sale solo", "Borrando...");
                        break;
                }
            }
        }

        private void CommandBinding_Executed_New(object sender, ExecutedRoutedEventArgs e)
        {
            if (modificado)
            {
                MessageBoxResult resultado = MessageBox.Show("Se ha modificado, ¿Guardar?", "Duda...", MessageBoxButton.YesNoCancel);
                switch (resultado)
                {
                    case MessageBoxResult.Yes:
                        try
                        {
                            if (fpath == "")
                            {
                                string rutaArchivo = InputBox("Guardar archivo como", "Ingresa la ruta del archivo:", "archivo.txt");
                                if (!string.IsNullOrEmpty(rutaArchivo))
                                {
                                    File.WriteAllText(rutaArchivo, Tedit.Text);
                                    modificado = false;
                                    fpath = rutaArchivo;
                                    Ventana1.Title = tituloA + " " + fpath;
                                }
                                else
                                {
                                    MessageBox.Show(" Cancelado ", "Na de na", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                }
                            }
                            else
                            {
                                File.WriteAllText(fpath, Tedit.Text);
                                modificado = false;
                                Ventana1.Title = tituloA + " " + fpath;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    case MessageBoxResult.No:
                        MessageBox.Show("Pantalla limpia", "Borrando...");
                        Tedit.Text = "";
                        fpath = "";
                        modificado = false;
                        Ventana1.Title = tituloA + " " + fpath;
                        break;
                    case MessageBoxResult.Cancel:
                        MessageBox.Show("Cancelado -> Na de na!", "Sin cambios");
                        break;
                }
            }
            else
            {
                Tedit.Text = "";
                fpath = "";
                modificado = false;
                Ventana1.Title = tituloA + " " + fpath;
            }
        }

        private void CommandBinding_Executed_Open(object sender, ExecutedRoutedEventArgs e)
        {
            if (modificado)
            {
                MessageBoxResult resultado = MessageBox.Show("Se ha modificado, ¿Guardar?", "Duda...", MessageBoxButton.YesNo);
                switch (resultado)
                {
                    case MessageBoxResult.Yes:
                        try
                        {
                            if (fpath == "")
                            {
                                string rutaArchivo = InputBox("Guardar archivo como", "Ingresa la ruta del archivo:", "archivo.txt");
                                if (!string.IsNullOrEmpty(rutaArchivo))
                                {
                                    File.WriteAllText(rutaArchivo, Tedit.Text);
                                    modificado = false;
                                    fpath = rutaArchivo;
                                    Ventana1.Title = tituloA + " " + fpath;
                                }
                                else
                                {
                                    MessageBox.Show(" Cancelado ", "Na de na", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                }
                            }
                            else
                            {
                                File.WriteAllText(fpath, Tedit.Text);
                                modificado = false;
                                Ventana1.Title = tituloA + " " + fpath;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                }
            }

            string rutaAbrir = InputBox("Abrir archivo", "Ingresa la ruta del archivo:", "");
            try
            {
                if (!string.IsNullOrEmpty(rutaAbrir))
                {
                    Tedit.Text = File.ReadAllText(rutaAbrir);
                    modificado = false;
                    fpath = rutaAbrir;
                    Ventana1.Title = tituloA + " " + fpath;
                }
                else
                {
                    MessageBox.Show(" No se ha seleccionado NADA", "Nada de nada", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el archivo: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CommandBinding_Executed_Save(object sender, ExecutedRoutedEventArgs e)
        {
            if (Mguardar.IsEnabled == true)
            {
                try
                {
                    if (fpath == "")
                    {
                        string rutaArchivo = InputBox("Guardar archivo como", "Ingresa la ruta del archivo:", "archivo.txt");
                        if (!string.IsNullOrEmpty(rutaArchivo))
                        {
                            using (StreamWriter sw = new StreamWriter(rutaArchivo))
                            {
                                sw.Write(Tedit.Text);
                            }

                            modificado = false;
                            fpath = rutaArchivo;
                            Ventana1.Title = tituloA + " " + fpath;
                        }
                        else
                        {
                            MessageBox.Show("Cancelado", "Na de na", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                    else
                    {
                        File.WriteAllText(fpath, Tedit.Text);
                        modificado = false;
                        Ventana1.Title = tituloA + " " + fpath;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CommandBinding_Executed_GuardarEn(object sender, ExecutedRoutedEventArgs e)
        {
            string rutaArchivo = InputBox("Guardar archivo como", "Ingresa la ruta del archivo:", "archivo.txt");
            try
            {
                if (!string.IsNullOrEmpty(rutaArchivo))
                {
                    using (StreamWriter sw = new StreamWriter(rutaArchivo))
                    {
                        sw.Write(Tedit.Text);
                    }

                    modificado = false;
                    fpath = rutaArchivo;
                    Ventana1.Title = tituloA + " " + fpath;
                }
                else
                {
                    MessageBox.Show("Cancelado", "Na de na", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CommandBinding_Executed_Print(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Imprimiendo ...");
        }

        private void CommandBinding_Executed_Help(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Help");
        }

        private void Tedit_TextChanged(object sender, TextChangedEventArgs e)
        {
            int fila = Tedit.GetLineIndexFromCharacterIndex(Tedit.CaretIndex);
            int columna = Tedit.CaretIndex - Tedit.GetCharacterIndexFromLineIndex(fila);
            Testado.Text = " Fila: " + (fila + 1).ToString() + ", Columna: " + (columna + 1).ToString();

            modificado = true;
            Ventana1.Title = tituloA + " *" + fpath;
            if (fpath != "") { Mguardar.IsEnabled = true; }
        }

        private void Tedit_KeyUp(object sender, KeyEventArgs e)
        {
            int fila = Tedit.GetLineIndexFromCharacterIndex(Tedit.CaretIndex);
            int columna = Tedit.CaretIndex - Tedit.GetCharacterIndexFromLineIndex(fila);
            Testado.Text = " Fila: " + (fila + 1).ToString() + ", Columna: " + (columna + 1).ToString();
        }

        private string InputBox(string title, string promptText, string defaultValue)
        {
            Window inputWindow = new Window
            {
                Title = title,
                Width = 300,
                Height = 150,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                WindowStyle = WindowStyle.ToolWindow,
                ResizeMode = ResizeMode.NoResize
            };

            StackPanel stackPanel = new StackPanel();

            Label prompt = new Label
            {
                Content = promptText,
                Margin = new Thickness(5)
            };

            TextBox textBox = new TextBox
            {
                Text = defaultValue,
                Margin = new Thickness(5)
            };

            Button okButton = new Button
            {
                Content = "OK",
                Width = 60,
                Margin = new Thickness(5),
                HorizontalAlignment = HorizontalAlignment.Left
            };

            okButton.Click += (sender, e) =>
            {
                inputWindow.DialogResult = true;
                inputWindow.Close();
            };

            stackPanel.Children.Add(prompt);
            stackPanel.Children.Add(textBox);
            stackPanel.Children.Add(okButton);

            inputWindow.Content = stackPanel;

            if (inputWindow.ShowDialog() == true)
            {
                return textBox.Text;
            }

            return string.Empty;
        }
    }

    public static class MisComandos
    {
        public static readonly RoutedUICommand GuardarEn = new RoutedUICommand
            (
                "Guardar en otro archivo",
                "GuardarEn",
                typeof(MisComandos),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.F2,ModifierKeys.Alt)
                }
            );
    }
}

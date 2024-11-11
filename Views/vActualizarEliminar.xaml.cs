using gpradoT7A.Models;
using System.Net;

namespace gpradoT7A.Views;

public partial class vActualizarEliminar : ContentPage
{
	public vActualizarEliminar(Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text = datos.Id.ToString();
        txtNombre.Text = datos.Nombre.ToString();
        txtApellido.Text = datos.Apellido.ToString();
        txtEdad.Text = datos.edad.ToString();
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient CLIENTE = new WebClient();

            // Construir la URL con todos los parámetros en la cadena de consulta
            string url = $"http://192.168.100.35:8081/uisraelws/estudiante.php?id={txtCodigo.Text}&nombre={txtNombre.Text}&apellido={txtApellido.Text}&edad={txtEdad.Text}";

            // Enviar la solicitud PUT
            CLIENTE.UploadString(url, "PUT", ""); // Enviar una solicitud vacía porque los datos van en la URL

            DisplayAlert("Éxito", "El estudiante ha sido actualizado correctamente", "Cerrar");

            // Navegar de regreso a la vista de estudiantes
            Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Cerrar");
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient CLIENTE = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("id", txtCodigo.Text); // Pasar el ID del estudiante como parámetro

            CLIENTE.UploadValues($"http://192.168.100.35:8081/uisraelws/estudiante.php?id={txtCodigo.Text}", "DELETE", parametros);

            DisplayAlert("Éxito", "El estudiante ha sido eliminado correctamente", "Cerrar");

            Navigation.PushAsync(new vEstudiante()); // Navegar de regreso a la vista de estudiantes
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Cerrar");
        }
    }
}
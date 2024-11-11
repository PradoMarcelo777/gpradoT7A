using System.Net;

namespace gpradoT7A.Views;

public partial class vInsertar : ContentPage
{
	public vInsertar()
	{
		InitializeComponent();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
	{  
		try
		{
			WebClient CLIENTE = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
			CLIENTE.UploadValues("http://192.168.100.35:8081/uisraelws/estudiante.php", "POST", parametros);
            DisplayAlert("Éxito", "El estudiante ha sido creado correctamente", "Cerrar");
            Navigation.PushAsync(new vEstudiante());

        }
        catch (Exception ex)
		{

			DisplayAlert("Error", ex.Message, "Cerrar");
		}

    }
}
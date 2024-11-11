using gpradoT7A.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace gpradoT7A.Views;

public partial class vEstudiante : ContentPage
{
    private const string Url = "http://192.168.100.35:8081/uisraelws/estudiante.php";
    private readonly HttpClient cliente = new HttpClient();

    //la lista en la interfaz de usuario se actualizara automaticamente cuando se agregue o elimines un estudiante.
    private ObservableCollection<Estudiante> todosLosEstudiantes;

    public vEstudiante()
	{
		InitializeComponent();
        mostrar();
    }

    //Agregar paquete Nugets Newtonsoft.Json
    public async void mostrar()
    {
        var datosEstudiantesJson = await cliente.GetStringAsync(Url); // Obtiene los datos JSON de la URL
        List<Estudiante> mostrarEstudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(datosEstudiantesJson); // Deserializa el JSON a una lista de estudiantes
        //Console.WriteLine(mostrarEstudiantes);
        todosLosEstudiantes = new ObservableCollection<Estudiante>(mostrarEstudiantes); // Convierte la lista en ObservableCollection
        listaEstudiantes.ItemsSource = todosLosEstudiantes; // Asigna la coleccion a la fuente de datos de la lista en la UI

    }

    private void btnInsetar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new vInsertar());
    }

    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objEstudiante = (Estudiante)e.SelectedItem;
        Navigation.PushAsync(new vActualizarEliminar(objEstudiante));
    }
}
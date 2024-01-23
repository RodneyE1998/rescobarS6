using Newtonsoft.Json;
using rescobarS6.Modelos;
using System.Collections.ObjectModel;

namespace rescobarS6.Vistas;

public partial class Inicio : ContentPage
{
	private const string Url = "http://10.2.11.117/moviles/ejercicio/post.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> estud;

    public Inicio()
	{
		InitializeComponent();
		obtener();
	}

	public async void obtener()
	{
		var content = await cliente.GetStringAsync(Url);
		List<Estudiante> mostrarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		estud = new ObservableCollection<Estudiante>(mostrarEst);
		listaEstudiantes.ItemsSource = estud;
	}

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new AgregarEstudiante());

    }

    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var objEstudiante = (Estudiante)e.SelectedItem;
		Navigation.PushAsync(new ActualizaEliminar(objEstudiante));
    }
}
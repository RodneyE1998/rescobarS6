using rescobarS6.Modelos;
using System.Net;

namespace rescobarS6.Vistas;

public partial class ActualizaEliminar : ContentPage
{
    public ActualizaEliminar(Estudiante datos)
    {
        InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text= datos.nombre;
        txtApellido.Text= datos.apellido;
        txtEdad.Text= datos.edad.ToString();
	}

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string edad = txtEdad.Text;


            string Url = "http://10.2.11.117/moviles/ejercicio/post.php?codigo=" + codigo + "&nombre=" + nombre + "&apellido=" + apellido + "&edad=" + edad;
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues(Url, "PUT", parametros);
            Navigation.PushAsync(new Inicio());

        }
        catch (Exception ex)
        {

            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }


    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
       try
        {
            string codigo = txtCodigo.Text;

            string Url = "http://10.2.11.117/moviles/ejercicio/post.php?codigo=" + codigo ;
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues(Url, "DELETE", parametros);
            Navigation.PushAsync(new Inicio());
        }
        catch (Exception ex)
        {

            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }

    }
}
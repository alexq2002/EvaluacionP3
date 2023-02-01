using System.Net;

namespace EvaluacionP3;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    public async void Button_Clicked(object sender, EventArgs e)
    {
        string cadena = Buscador.Text;
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri("https://www.themealdb.com/api/json/v1/1/search.php?f=" + cadena);
        request.Method = HttpMethod.Get;
        request.Headers.Add("Accept", "application/json");

        var client = new HttpClient();

        HttpResponseMessage response = await client.SendAsync(request);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            String content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<ComidaAQ>>(content);
            ListaDemo.ItemsSource = resultado;
        }
    }
}


using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpResponse response) => returnSomething(response));

app.MapPost("/saveproduct", (Product p) => {
    return p.Code + " - " + p.Name;
});

app.MapGet("/getprod", ([FromQuery] string dateStart,[FromQuery] string dateEnd) => {
    return dateStart + " - " + dateEnd;
});

app.MapGet("/getprod/{code}", ([FromRoute] string code) => {
    return code;
});

app.MapGet("/getheader", (HttpRequest request) => {
    return request.Headers["get-product"].ToString();
});

app.Run();


object returnSomething(HttpResponse response){
    
    response.Headers.Add("boring", "teucu");
    return new {nome= "lucas", teste1 = "teste2"};
}


public class Product{
    public string Code { get; set; }
    public string Name{  get; set; }


    public Product(string code, string name){
        Code = code;
        Name = name;
    }
}


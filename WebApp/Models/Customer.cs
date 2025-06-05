using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models;

public class Customer 
{
  public int Id {get; set;}   
  public string  FirstName {get; set;}
  public string  LastName {get; set;}
  public string  Street {get; set;}
  public string  PostalCode {get; set;}
  public int AppartmentNumber {get; set;}
}

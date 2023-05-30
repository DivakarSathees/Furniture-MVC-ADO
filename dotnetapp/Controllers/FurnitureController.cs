using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetapp.Models;
using System.Data;
using Microsoft.Data.SqlClient;

public class FurnitureController : Controller
{
    

    private string connectionString = "User ID=sa;password=examlyMssql@123;server=dffafdafebcfacbdcbaeadbebabcdebdca-0;Database=FurnitureDB;trusted_connection=false;Persist Security Info=False;Encrypt=False";

    public ActionResult Index()
    {
        List<Furniture> furnitures = new List<Furniture>();
    try
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Furniture";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Furniture furniture = new Furniture();

                    furniture.id = Convert.ToInt32(reader["id"]);
                    furniture.Product = reader["Product"].ToString();
                    furniture.Description = reader["Description"].ToString();
                    furniture.Material = reader["Material"].ToString();
                    furniture.Dimensions = reader["Dimensions"].ToString();
                    // furniture.Price = reader["Price"].ToString();
                    furniture.Price = decimal.Parse(reader["Price"].ToString());

                    furnitures.Add(furniture);
                }

                reader.Close();
            }
        }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
        return View(furnitures);

    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Furniture furniture)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Furniture (Product, Description, Material, Dimensions, Price) VALUES (@Product, @Description, @Material,@Dimensions, @Price)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // command.Parameters.AddWithValue("@id", Book.id);
                command.Parameters.AddWithValue("@Product", furniture.Product);
                command.Parameters.AddWithValue("@Description", furniture.Description);
                command.Parameters.AddWithValue("@Material", furniture.Material);
                command.Parameters.AddWithValue("@Dimensions", furniture.Dimensions);
                command.Parameters.AddWithValue("@Price", furniture.Price);


                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        return RedirectToAction("Index");
    }


    public ActionResult Edit(int id)
    {
    Furniture furniture = new Furniture();

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        string query = "SELECT * FROM Furniture WHERE id = @id";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@id", id);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                furniture.id = Convert.ToInt32(reader["id"]);
                furniture.Product = reader["Product"].ToString();
                furniture.Description = reader["Description"].ToString();
                furniture.Material = reader["Material"].ToString();
                furniture.Dimensions = reader["Dimensions"].ToString();
                // furniture.Price = reader["Price"].ToString();
                furniture.Price = decimal.Parse(reader["Price"].ToString());

            }

            reader.Close();
        }
    }

    return View(furniture);
}

    [HttpPost]
    public ActionResult Edit(Furniture furniture)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE Furniture SET Product = @Product, Description = @Description, Material = @Material, Dimensions = @Dimensions, Price = @Price WHERE id = @id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", furniture.id);
                Console.WriteLine(furniture.id);
                command.Parameters.AddWithValue("@Product", furniture.Product);
                                Console.WriteLine(furniture.Product);

                command.Parameters.AddWithValue("@Description", furniture.Description);
                command.Parameters.AddWithValue("@Material", furniture.Material);
                command.Parameters.AddWithValue("@Dimensions", furniture.Dimensions);
                command.Parameters.AddWithValue("@Price", furniture.Price);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        string query = "DELETE FROM Furniture WHERE id = @id";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@id", id);

            connection.Open();

            command.ExecuteNonQuery();
        }
    }

    return RedirectToAction("Index");
    }


}
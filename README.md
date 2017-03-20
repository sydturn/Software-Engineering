## Notes

#### Basic Database Queries

When making a query to the database, follow this:

```C#
  if (dbConnection.OpenConnection()) // Check and open the database connection.
  {
    MySqlCommand command = new MySqlCommand(); // Used to create a query command.
    
    command.Connection = dbConnection.getConnection(); // Assigns the database to the command.
    command.CommandText = "SELECT * from example"; // The query string.
    
    // OPTION #1: If reading from the database:  
    using (MySqlDataReader dr = command.ExecuteReader())
    {
      while (dr.Read())
      {
        String firstItem = dr[0].ToString();
        int secondItem = Int32.Parse(dr[1].ToString());
      }
    }
    
    // OPTION #2: If using other queries like insert, update, etc:
    command.ExecuteNonQuery();
    
    dbConnection.CloseConnection(); // Close the connection.
    command.Dispose(); // Dispose of the command object after use.
  }    
```

## Project To-do List

#### System Administrator Form

* Modify users.
* Ability to add/delete postings when secretary form is done.

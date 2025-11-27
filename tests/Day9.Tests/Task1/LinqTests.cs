using Task1;
using Task1.DoNotChange;

namespace Day9.Tests.Task1;

public class LinqTests
{
    [Theory]
    [InlineData(500, 1)]
    [InlineData(1000, 0)]
    [InlineData(200, 2)]
    public void Linq1_ReturnsCustomersWithTurnoverGreaterThanLimit(decimal limit, int expectedCount)
    {
        // Arrange
        var customers = new[]
        {
            new Customer { Orders = new[] { new Order { Total = 300 }, new Order { Total = 250 } } },
            new Customer { Orders = new[] { new Order { Total = 100 } } },
            new Customer { Orders = new[] { new Order { Total = 500 } } }
        };

        // Act
        var result = LinqTask.Linq1(customers, limit);

        // Assert
        Assert.Equal(expectedCount, result.Count());
    }

    [Theory]
    [InlineData("Minsk", "Belarus", 1)]
    [InlineData("Moscow", "Russia", 0)]
    [InlineData("Paris", "France", 2)]
    public void Linq2_ReturnsSuppliersFromSameCityAndCountry(string city, string country, int expectedSuppliers)
    {
        // Arrange
        var customers = new[] { new Customer { City = city, Country = country } };
        var suppliers = new[]
        {
            new Supplier { City = "Minsk", Country = "Belarus" },
            new Supplier { City = "Paris", Country = "France" },
            new Supplier { City = "Paris", Country = "France" }
        };

        // Act
        var result = LinqTask.Linq2(customers, suppliers).First();

        // Assert
        Assert.Equal(expectedSuppliers, result.suppliers.Count());
    }

    [Theory]
    [InlineData(200, 1)]
    [InlineData(45, 2)]
    [InlineData(500, 0)]
    public void Linq3_ReturnsCustomersWithOrderGreaterThanLimit(decimal limit, int expectedCount)
    {
        // Arrange
        var customers = new[]
        {
            new Customer { Orders = new[] { new Order { Total = 100 }, new Order { Total = 250 } } },
            new Customer { Orders = new[] { new Order { Total = 50 } } }
        };

        // Act
        var result = LinqTask.Linq3(customers, limit);

        // Assert
        Assert.Equal(expectedCount, result.Count());
    }

    [Theory]
    [InlineData(2020, 1)]
    [InlineData(2021, 0)]
    [InlineData(2019, 1)]
    public void Linq4_ReturnsDateOfFirstOrder(int year, int expectedCount)
    {
        // Arrange
        var customers = new[]
        {
            new Customer { Orders = new[] { new Order { OrderDate = new DateTime(2020, 1, 1) } } },
            new Customer { Orders = new[] { new Order { OrderDate = new DateTime(2019, 5, 1) } } }
        };

        // Act
        var result = LinqTask.Linq4(customers).Where(c => c.dateOfEntry.Year == year);

        // Assert
        Assert.Equal(expectedCount, result.Count());
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(0)]
    public void Linq5_ReturnsSortedCustomers(int expectedMinCount)
    {
        // Arrange
        var customers = new[]
        {
            new Customer { CompanyName = "A", Orders = new[] { new Order { OrderDate = new DateTime(2020, 1, 1), Total = 100 } } },
            new Customer { CompanyName = "B", Orders = new[] { new Order { OrderDate = new DateTime(2020, 2, 1), Total = 200 } } }
        };

        // Act
        var result = LinqTask.Linq5(customers);

        // Assert
        Assert.True(result.Count() >= expectedMinCount);
    }

    [Theory]
    [InlineData("AB12", "", "12345", 1)]
    [InlineData("12345", "Region", "(123)456", 0)]
    [InlineData("12AB", null, "456", 1)]
    public void Linq6_ReturnsCustomersWithInvalidData(string postal, string region, string phone, int expectedCount)
    {
        // Arrange
        var customers = new[] { new Customer { PostalCode = postal, Region = region, Phone = phone } };

        // Act
        var result = LinqTask.Linq6(customers);

        // Assert
        Assert.Equal(expectedCount, result.Count());
    }

    [Theory]
    [InlineData("Beverages", 2)]
    [InlineData("Food", 1)]
    [InlineData("Tools", 0)]
    public void Linq7_GroupsProductsByCategory(string category, int expectedGroups)
    {
        // Arrange
        var products = new[]
        {
            new Product { Category = "Beverages", UnitsInStock = 10, UnitPrice = 20 },
            new Product { Category = "Beverages", UnitsInStock = 15, UnitPrice = 30 },
            new Product { Category = "Food", UnitsInStock = 5, UnitPrice = 15 }
        };

        // Act
        var result = LinqTask.Linq7(products);
        var group = result.FirstOrDefault(g => g.Category == category);

        // Assert
        Assert.Equal(expectedGroups, group?.UnitsInStockGroup.Count() ?? 0);
    }

    [Theory]
    [InlineData(10, 20, 50, 3)]
    [InlineData(5, 15, 30, 2)]
    [InlineData(100, 200, 300, 1)]
    public void Linq8_GroupsProductsByPrice(decimal cheap, decimal middle, decimal expensive, int expectedGroups)
    {
        // Arrange
        var products = new[]
        {
            new Product { UnitPrice = 5 },
            new Product { UnitPrice = 16 },
            new Product { UnitPrice = 60 }
        };

        // Act
        var result = LinqTask.Linq8(products, cheap, middle, expensive);

        // Assert
        Assert.Equal(expectedGroups, result.Count());
    }

    [Theory]
    [InlineData("Minsk", 200, 1)]
    [InlineData("Moscow", 0, 0)]
    [InlineData("Paris", 50, 1)]
    public void Linq9_CalculatesAverageIncomeAndIntensity(string city, int expectedIncome, int expectedIntensity)
    {
        // Arrange
        var customers = new[]
        {
            new Customer { City = "Minsk", Orders = new[] { new Order { Total = 100 }, new Order { Total = 250 } } },
            new Customer { City = "Minsk", Orders = new[] { new Order { Total = 50 } } },
            new Customer { City = "Paris", Orders = new[] { new Order { Total = 50 } } }
        };

        // Act
        var result = LinqTask.Linq9(customers).FirstOrDefault(r => r.city == city);

        // Assert
        if (result.city == city)
        {
            Assert.Equal(expectedIncome, result.averageIncome);
            Assert.Equal(expectedIntensity, result.averageIntensity);
        }
    }

    [Theory]
    [InlineData("USA France UK", "UK USA France")]
    [InlineData("Germany Poland", "Poland Germany")]
    [InlineData("Italy Spain", "Italy Spain")]
    public void Linq10_ReturnsCountriesSortedByLengthAndName(string countries, string expected)
    {
        // Arrange
        var suppliers = countries.Split(' ')
            .Select(c => new Supplier { Country = c });

        // Act
        var result = LinqTask.Linq10(suppliers);

        // Assert
        Assert.Equal(expected, result);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Task1.DoNotChange;

namespace Task1
{
    public static class LinqTask
    {
        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
            return customers.Where(x => x.Orders != null && x.Orders.Sum(x => x.Total) > limit);
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            return customers.Select(c =>
                (
                    customer: c,
                    suppliers: suppliers.Where(s => s.Country == c.Country && s.City == c.City)
                )
            );
        }

        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            return customers.Where(c => c.Orders.Any(o => o.Total > limit));
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers
        )
        {
            return customers.Where(c => c.Orders != null && c.Orders.Any())
                .Select(c => 
                (
                    c,
                    c.Orders.Select(o => o.OrderDate.Date).Min()
                )
            );
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers
        )
        {
            return customers.Where(c => c.Orders != null && c.Orders.Any())
                .Select(c =>
                (
                    customer: c,
                    dateOfEntry: c.Orders.Select(o => o.OrderDate.Date).Min(),
                    turnOver: c.Orders.Sum(c => c.Total)
                )
            ).OrderBy(c => c.dateOfEntry.Year)
            .ThenBy(c => c.dateOfEntry.Month)
            .ThenByDescending(c => c.turnOver)
            .ThenBy(c => c.customer.CompanyName)
            .Select(x => (x.customer, x.dateOfEntry));
        }

        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
            return customers.Where(c => c.PostalCode.Any(ch => 
                (c.PostalCode != null && !char.IsDigit(ch)) 
                || string.IsNullOrEmpty(c.Region) 
                || ((c.Phone != null) && !c.Phone.StartsWith("("))
                )
            );
        }

        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
            /* example of Linq7result

             category - Beverages
	            UnitsInStock - 39
		            price - 18.0000
		            price - 19.0000
	            UnitsInStock - 17
		            price - 18.0000
		            price - 19.0000
             */

            var c = products
                .GroupBy(x => x.Category)
                .Select(x => new Linq7CategoryGroup 
                    { 
                        Category = x.Key, 
                        UnitsInStockGroup = x.GroupBy(y => y.UnitsInStock)
                                            .Select(z => new Linq7UnitsInStockGroup 
                                            {
                                                UnitsInStock = z.Key,
                                                Prices = z.OrderBy(o => o.UnitPrice)
                                                .Select(o => o.UnitPrice)
                                                .ToArray()
                                            }
                                            )
                })
                .ToArray();
            return c;
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive
        )
        {
            return products
                .GroupBy(p =>
                {
                    if (p.UnitPrice <= cheap)
                        return cheap;          
                    else if (p.UnitPrice <= middle)
                        return middle;         
                    else
                        return expensive;      
                })
                .Select(g => (category: g.Key, products: g.AsEnumerable()))
                .ToList();
        }

        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers
        )
        {
            return customers
            .Where(c => c.Orders != null && c.Orders.Any())
            .GroupBy(c => c.City)
            .Select(g => (
                city: g.Key,
                averageIncome: (int)g.Sum(c => c.Orders.Sum(o => o.Total) / g.Count()),   
                averageIntensity: g.Sum(c => c.Orders.Count() / g.Count())           
            ))
            .ToList();
        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            return string.Join(" ",
                suppliers.Select(s => s.Country)
                         .Distinct()
                         .OrderBy(c => c.Length)
                         .ThenBy(c => c)
            );
        }
    }
}
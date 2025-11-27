## Задачи
---

 **1.** LINQ

- 1. Return all customers whose total turnover (the sum of all orders) exceeds some value X;
- 2.	For each customer, make a list of suppliers located in the same country and same city.
- 3.	Find all customers who had at least one order greater than X;
- 4.	Return a list of customers indicating the date they became customers starting from (take the date of the very first order as such);
- 5.	Do the previous task, but return the list sorted by year, month, client turnover (from maximum to minimum) and client name;	Return all customers who have a non-numeric postal code, or region is not filled in, or the operator code is not specified in the phone (for simplicity, let’s consider that this is equivalent to “no parentheses at the beginning”);
- 7.	Group all products by category, inside - by stock, inside the last group sort by cost;
- 8.	Group products into groups "cheap", "average price", "expensive". (0, cheap] U (cheap, average price] U (average price, expensive];
- 9.	Calculate the average profitability of each city (the average amount of orders per customer) and the average intensity (the average number of orders per customer from each city);
- 10.	Return a string consisting of the unique names of the countries of suppliers, sorted first by length, then by country name.

**Реализация -  
ссылки на решение:**
- [Algorithms](LinqTask.cs)  
- [Модульные тесты](../../../tests/Day9.Tests/Task1/)
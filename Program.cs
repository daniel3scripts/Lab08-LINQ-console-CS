using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lab08Console
{
    class Program
    {
        public static DataClasses1DataContext context = new DataClasses1DataContext();
        static void Main(string[] args)
        {
            IntroToLINQ();

               
            Console.ReadKey();
            DataSource();

            Console.ReadKey();
            Filtering();
            Console.ReadKey();
            Ordering();
            Console.ReadKey();
            Grouping();
            Console.ReadKey();
            Grouping2();
            Console.ReadKey();
            Joining();
            LambdaIntroToLINQ();
            Console.ReadKey();
            LambdaFiltering();
            Console.ReadKey();
            LambdaOrdering();
            Console.ReadKey();
            LambdaGrouping();
            Console.ReadKey();
            LambdaGrouping2();
            Console.ReadKey();
            LambdaJoining();
            Console.ReadKey();
            LambdaDataSource();
            Console.Read();
            //Console.Clear(); 

        }
        static void IntroToLINQ()
        {
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;
            foreach (int num in numQuery)
            {
                Console.WriteLine("{0,1}", num);
                

            }
        }
        
        static void DataSource()
        {
             var queryAllCustomer = from cust in context.clientes
                                    select cust;
            foreach (var item in queryAllCustomer)
            {
                Console.WriteLine(item.NombreCompañia);
                
            }
        }

        static void Filtering()
        {
            var queryLondonCustomer = from cust in context.clientes
                                      where cust.Ciudad == "Londres"
                                      select cust;
            foreach (var item in queryLondonCustomer)

            {
                Console.WriteLine(item.Ciudad);
            }
        }
        
        static void Ordering()
        {
            var queryLondovCustomer2 = from cust in context.clientes
                                       where cust.Ciudad == "London"
                                       orderby cust.NombreCompañia ascending
                                       select cust;
            foreach (var item in queryLondovCustomer2)
            {
                Console.WriteLine(item.NombreCompañia);
            }
        } 

        static void Grouping()
        {
            var queryCustomerByCity = from cust in context.clientes
                                      group cust by cust.Ciudad;

            foreach (var customerGroup in queryCustomerByCity)
            {
                Console.WriteLine(customerGroup.Key);
                foreach (clientes customer in customerGroup)
                {
                    Console.Write(" {0}", customer.NombreCompañia);
                }
            }
        }

        static void Grouping2()
        {
            var custQuery = from cust in context.clientes
                            group cust by cust.Ciudad into custoGroup
                            where custoGroup.Count() > 2
                            orderby custoGroup.Key
                            select custoGroup;
            foreach (var customer in custQuery)
            {
                Console.WriteLine(customer.Key);
            }
        }
         static void Joining()
        {
            var innerJoinQuery = from cust in context.clientes
                                 join dist in context.Pedidos on cust.idCliente equals dist.IdCliente
                                 select new { CustomerName = cust.NombreCompañia, DistributorName = dist.PaisDestinatario };
            foreach (var innerJoin in innerJoinQuery)
            {
                Console.WriteLine(innerJoin.CustomerName);
            }
                                 
        }

        static void LambdaIntroToLINQ()
        {
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
            var nums = numbers.Where(n => n % 2 == 0);

            foreach (int num in nums)
            {
                Console.Write("{0,1} ", num);
            }

        }

        static void LambdaFiltering()
        {
            var queryLondonCustomer =
                context.clientes.Where(c => c.Ciudad == "Londres");

            foreach (var item in queryLondonCustomer)
            {
                Console.WriteLine(item.Ciudad);
            }

        }

        static void LambdaOrdering()
        {
            var queryLondonCustomers2 = context.clientes
                .Where(c => c.Ciudad == "Londres")
                .OrderBy(c => c.NombreCompañia);

            foreach (var item in queryLondonCustomers2)
            {
                Console.WriteLine(item.NombreCompañia);
            }

        }

        static void LambdaGrouping()
        {
            var queryCustomersByCity = context.clientes.GroupBy(c => c.Ciudad);

            foreach (var customerGroup in queryCustomersByCity)
            {
                Console.WriteLine(customerGroup.Key);
                foreach (clientes customer in customerGroup)
                {
                    Console.WriteLine("{0}", customer.NombreCompañia);
                }
            }

        }

        static void LambdaGrouping2()
        {
            var custQuery = context.clientes.GroupBy(x => x.Ciudad)
                            .Where(x => x.Count() > 2).OrderBy(x => x.Key);
            foreach (var customer in custQuery)
            {
                Console.WriteLine(customer.Key );
            }
        }

       static void LambdaJoining()
        {
            var innerJoinQuery = context.clientes
                .Join(context.Pedidos, cust => cust.idCliente,
                dist => dist.IdCliente,
                (cust,dist)=> new { CustomerName = cust.NombreCompañia,
                DistrbutorName = dist.PaisDestinatario});
            foreach (var innerJoin in innerJoinQuery)
            {
                Console.WriteLine(innerJoin.CustomerName);
            
            }

        }

        static void LambdaDataSource()
        {
            var queryAllCustomer = context.clientes;
            foreach (var item in queryAllCustomer)
            { 
                Console.WriteLine(item.NombreCompañia);
            }
        }

    }
}

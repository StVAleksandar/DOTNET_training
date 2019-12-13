using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using InfrastructuredServices;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerService lService = new LoggerService();
            MailSenderService service = new MailSenderService();
            CustomersRepository repository = new CustomersRepository();

            //service.sendEmail("Mail Subject", "Mail text hublabla", "aleksandar_sd@hotmail.com", "st.v.aleksandar@gmail.com", "########", "Aleksandar Stojanovic");
            //lService.logInfo("trzy12");



            //List<Suppliers> products = repository.getAllSuppliers();

            Customers product = new Customers();
            product = repository.getCustomerByID("ALFKI");



            //Suppliers product = new Suppliers()
            //{
            //    supplierID = 30,
            //    companyName = "Acin produktt",
            //    contactName = "Acin produktt",
            //    contactTitle = "Acin produktt",
            //    address = "blabl labs",
            //    city = "Acin produktt",
            //    region = "Acin produktt",
            //    postalCode = "Acin produktt",
            //    country = "Acin produktt",
            //    phone = "Acin produktt",
            //    fax = "Acin produktt",
            //    homePage = "Acin produktt"
            //};
            //repository.addSupplier(product);

            //repository.updateProduct(product);

            //repository.deleteProduct(78);




            Console.WriteLine(product);
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BussinesServices
{
    public class ProductsService
    {
        ProductsRepository repository = new ProductsRepository();

        public int addProducts(string productName, int supplierID, int categoryID, string quantityPerUnit, decimal unitPrice, short unitsInStock, short unitsOnOrder, short reorderLevel, bool discontinued)
        {
            List<Products> allProducts = repository.getAllProducts();

            foreach (Products p in allProducts)
            {
                if (Equals(p.productName, productName))
                {
                    return 0;
                }
            }

            Products product = new Products()
            {
                productName = productName,
                supplierID = supplierID,
                categoryID = categoryID,
                quantityPerUnit = quantityPerUnit,
                unitPrice = unitPrice,
                unitsInStock = unitsInStock,
                unitsOnOrder = unitsOnOrder,
                reorderLevel = reorderLevel,
                discontinued = discontinued
            };

            repository.addProduct(product);
            return 1;
        }



        public int deleteProducts(int id)
        {
            Products product = new Products();

            product = repository.getProductById(id);

            if (product.unitsOnOrder == 0)
            {
                repository.deleteProduct(id);
                return 1;
            }
            else
            {
                return 0;   
            }
        }
    }
}

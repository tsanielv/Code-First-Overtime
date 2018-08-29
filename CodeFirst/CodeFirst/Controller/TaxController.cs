using System;
using CodeFirst.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Controller
{
    class TaxController
    {
        BaseContext _context = new BaseContext();
        public void Menu()
        {
            BaseContext _context = new BaseContext();
            int input;

            System.Console.WriteLine("====================================");
            Console.WriteLine("1. Insert Data Tax");
            Console.WriteLine("2. Lihat  Data Semua Tax");
            Console.WriteLine("3. Get By ID Tax");
            Console.WriteLine("4. Update Data Tax");
            Console.WriteLine("5. Delete Data Tax");
            Console.WriteLine("====================================");
            Console.Write("Pilih Menu = ");
            int pilih = Convert.ToInt32(Console.ReadLine());

            switch (pilih)
            {
                case 1:
                    Insert();
                    Console.ReadKey();
                    break;

                case 2:
                    GetAll();
                    Console.ReadKey();
                    break;

                case 3:
                    Console.Clear();
                    Console.Write("Masukkan Id yang dicari : ");
                    input = Convert.ToInt32(Console.ReadLine());
                    getById(input);
                    Console.ReadKey();
                    break;

                case 4:
                    Console.Clear();
                    Console.Write("Masukkan Id yang dicari : ");
                    input = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("===========================");
                    Console.WriteLine("Data Sebelum Diubah");
                    Console.WriteLine("===========================");
                    getById(input);
                    Console.WriteLine("===========================");
                    Update(input);
                    Console.WriteLine("===========================");
                    Console.WriteLine("Data Setelah Diubah");
                    Console.WriteLine("===========================");
                    getById(input);
                    Console.WriteLine("===========================");
                    Console.ReadKey();
                    break;

                case 5:
                    Console.Clear();
                    Console.Write("Masukkan Id yang didihapus : ");
                    input = Convert.ToInt32(Console.ReadLine());
                    Delete(input);
                    Console.ReadKey();
                    break;
            }
        }


        public void Insert()
        {

            Console.Write("Masukkan Nama Type : ");
            char type_tax = Convert.ToChar(Console.ReadLine());
            Console.Write("Masukkan Amount : ");
            int amount_tax = Convert.ToInt32(Console.ReadLine());

            Tax tax = new Tax()
            {
                type = type_tax,
                amount = amount_tax
            };
            try
            {
                _context.Tax.Add(tax);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write(e.InnerException);
                Console.Write(e.Message);
                Console.Write(e.StackTrace);
            }
        }

        public List<Tax> GetAll()
        {
            Console.Clear();

            var getAll = _context.Taxes.ToList();
            foreach (Tax tax in getAll)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id     : " + tax.id);
                Console.WriteLine("Type   : " + tax.type);
                Console.WriteLine("Amount : " + tax.amount);
                Console.WriteLine("-------------------------");
            }

            return getAll;
        }


        public Tax getById(int input)
        {
            var tax = _context.Taxes.Find(input);
            if (tax == null)
            {
                Console.WriteLine("Id yang dicari tidak ada");
            }
            else if (tax.id == input)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id     : " + tax.id);
                Console.WriteLine("Type   : " + tax.type);
                Console.WriteLine("Amount : " + tax.amount);
                Console.WriteLine("-------------------------");
            }
            return tax;
        }

        public Tax searchId(int input)
        {
            var tax = _context.Taxes.Find(input);
            if (tax == null)
            {
                Console.WriteLine("Id yang dicari tidak ada");
            }

            return tax;
        }

        public int Update(int input)
        {
            Console.Write("Masukkan Type Baru   :");
            char new_type = Convert.ToChar(Console.ReadLine());
            Console.Write("Masukkan Amount Baru :");
            int new_amount = Convert.ToInt32(Console.ReadLine());

            var gettax = _context.Taxes.Find(input);
            if (gettax == null)
            {
                Console.WriteLine("Id yang dicari tidak ada");
            }
            else
            {
                Tax tax = searchId(input);
                tax.type = new_type;
                tax.amount = new_amount;

                _context.Entry(tax).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            return input;
        }

        public int Delete(int input)
        {
            Tax tax = _context.Taxes.Find(input);
            _context.Entry(tax).State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChanges();

            return input;
        }
    }
}

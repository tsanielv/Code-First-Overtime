using System;
using CodeFirst.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Controller
{
    class CustomerController
    {
        BaseContext _context = new BaseContext();
        public void Menu()
        {
            BaseContext _context = new BaseContext();
            int input;

            System.Console.WriteLine("====================================");
            Console.WriteLine("1. Insert Data Customer");
            Console.WriteLine("2. Lihat  Data Semua Customer");
            Console.WriteLine("3. Get By ID Customer");
            Console.WriteLine("4. Update Data Customer");
            Console.WriteLine("5. Delete Data Customer");
            Console.WriteLine("====================================");
            Console.Write("Pilih Menu = ");
            int pilih = Convert.ToInt32(Console.ReadLine());

            switch (pilih)
            {

            }
        }

        //method Insert untuk menambahkan data baru ke dalam tabel customer
    }
}

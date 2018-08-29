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
                    Console.Write("Masukkan Id yang akan diupdate : ");
                    input = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("===========================");
                    Console.WriteLine("Data Sebelum Diubah");
                    Console.WriteLine("===========================");

                    // method getById akan menampilkan data yang lama 
                    getById(input);
                    Console.WriteLine("===========================");

                    //User menginputkan data baru
                    Update(input);
                    Console.WriteLine("===========================");
                    Console.WriteLine("Data Setelah Diubah");
                    Console.WriteLine("===========================");

                    //method getById dipanggil lagi untuk menampilkan data yang telah diupdate
                    getById(input);
                    Console.WriteLine("===========================");
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    Console.Write("Masukkan Id yang ingin dihapus : ");
                    input = Convert.ToInt32(Console.ReadLine());
                    Delete(input);
                    Console.ReadKey();
                    break;

            }
        }

        //method Insert untuk menambahkan data baru ke dalam tabel customer

        public void Insert()
        {
            //inputan oleh user
            Console.Write("Masukkan Nama Customer : ");
            string nama_customer = Console.ReadLine();

            //proses penyimpanan ke database
            Role role = new Role()
            {
                name = nama_customer
            };
            try
            {
                _context.Roles.Add(role);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write(e.InnerException);
                Console.Write(e.Message);
                Console.Write(e.StackTrace);
            }
        }

        //method GetAll untuk melihat semua data yang ada di tabel customer
        public List<Customer> GetAll()
        {
            Console.Clear();

            //proses pengambilan data dari tabel role
            var getAll = _context.Customers.ToList();
            foreach (Customer customer in getAll)
            {
                //proses penampilan data
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id   : " + customer.id);
                Console.WriteLine("Name : " + customer.name);
                Console.WriteLine("-------------------------");
            }

            return getAll;
        }


        //method getById untuk menampilkan data berdasarkan id yang diinputkan oleh user dengan parameter variabel input
        public Customer getById(int input)
        {
            //proses mencari id yang diinputkan oleh user dan menampilkan hasilnya
            var customer = _context.Customers.Find(input);
            if (customer == null)
            {
                Console.WriteLine("Id yang dicari tidak ada");
            }
            else if (customer.id == input)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id   : " + customer.id);
                Console.WriteLine("Name : " + customer.name);
                Console.WriteLine("-------------------------");
            }
            return customer;
        }


        //method searchId untuk mencari data berdasarkan id yang nantinya akan di update (semacam input where-nya gitu deh)
        public Customer searchId(int input)
        {
            var customer = _context.Customers.Find(input);
            if (customer == null)
            {
                Console.WriteLine("Id yang dicari tidak ada");
            }

            return customer;
        }


        //Method Update untuk update tabel Role dengan parameter id variabel input (inputan user)
        public int Update(int input)
        {
            //memasukkan data baru
            Console.Write("Masukkan Nama Baru :");
            string new_name = Console.ReadLine();

            var getcust = _context.Customers.Find(input);
            if (getcust == null)
            {
                Console.WriteLine("Id yang dicari tidak ada");
            }
            else
            {
                //proses penyimpanan ke database
                Customer customer = searchId(input);
                customer.name = new_name;

                _context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            return input;
        }


        //Method Delete untuk menghapus data dengan parameter id variabel input (inputan user)
        public int Delete(int input)
        {
            Customer customer = _context.Customers.Find(input);
            _context.Entry(customer).State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChanges();
            return input;
        }
    }
}

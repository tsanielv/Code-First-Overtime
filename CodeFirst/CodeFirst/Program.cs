using System;
using CodeFirst.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Program
    {
        BaseContext _context = new BaseContext();
       public static void Main(string[] args)
        {
            BaseContext _context = new BaseContext();
            Program p = new Program();
            int input;

            Console.WriteLine("====================================");
            Console.WriteLine("1. Insert Data Department");
            Console.WriteLine("2. Lihat  Data Semua Department");
            Console.WriteLine("3. Get By ID Department");
            Console.WriteLine("4. Update Data Department");
            Console.WriteLine("5. Update Data Department");
            Console.WriteLine("====================================");
            Console.Write("Pilih Menu = ");
            int pilih = Convert.ToInt32(Console.ReadLine());

            switch (pilih)
            {
                case 1:
                    p.Insert();
                    break;
            }
        }

        public void Insert()
        {

            Console.Write("Masukkan Nama Department : ");
            string nama_department = Console.ReadLine();

            Department department = new Department()
            {
                name = nama_department
            };
            try
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
            }catch (Exception e)
            {
                Console.Write(e.InnerException);
                Console.Write(e.Message);
                Console.Write(e.StackTrace);
            }
        }
    }
}

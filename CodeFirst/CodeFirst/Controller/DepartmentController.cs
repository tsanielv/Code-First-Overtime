using System;
using CodeFirst.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Controller
{
    class DepartmentController
    {
        BaseContext _context = new BaseContext();
        public void Menu()
        {
            BaseContext _context = new BaseContext();
            int input;

            System.Console.WriteLine("====================================");
            Console.WriteLine("1. Insert Data Department");
            Console.WriteLine("2. Lihat  Data Semua Department");
            Console.WriteLine("3. Get By ID Department");
            Console.WriteLine("4. Update Data Department");
            Console.WriteLine("5. Delete Data Department");
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
            }
            catch (Exception e)
            {
                Console.Write(e.InnerException);
                Console.Write(e.Message);
                Console.Write(e.StackTrace);
            }
        }

        public List<Department> GetAll()
        {
            Console.Clear();

            var getAll = _context.Departments.ToList();
            foreach (Department department in getAll)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id   : " + department.id);
                Console.WriteLine("Name : " + department.name);
                Console.WriteLine("-------------------------");
            }

            return getAll;
        }


        public Department getById(int input)
        {
            var department = _context.Departments.Find(input);
            if (department == null)
            {
                Console.WriteLine("Id yang dicari tidak ada");
            }
            else if (department.id == input)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id   : " + department.id);
                Console.WriteLine("Name : " + department.name);
                Console.WriteLine("-------------------------");
            }
            return department;
        }

        public Department searchId(int input)
        {
            var department = _context.Departments.Find(input);
            if (department == null)
            {
                Console.WriteLine("Id yang dicari tidak ada");
            }

            return department;
        }

        public int Update(int input)
        {
            Console.Write("Masukkan Nama Baru :");
            string new_name = Console.ReadLine();

            var getdepartment = _context.Departments.Find(input);
            if (getdepartment == null)
            {
                Console.WriteLine("Id yang dicari tidak ada");
            }
            else
            {
                Department department = searchId(input);
                department.name = new_name;

                _context.Entry(department).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            return input;
        }

        public int Delete(int input)
        {
            Department department = _context.Departments.Find(input);
            _context.Entry(department).State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChanges();

            return input;
        }
    }
}

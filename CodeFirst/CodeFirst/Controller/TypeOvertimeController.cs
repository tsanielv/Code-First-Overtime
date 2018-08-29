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
            Console.WriteLine("1. Insert Data Type Overtime");
            Console.WriteLine("2. Lihat  Data Semua Type Overtime");
            Console.WriteLine("3. Get By ID Type Overtime");
            Console.WriteLine("4. Update Data Type Overtime");
            Console.WriteLine("5. Delete Data Type Overtime");
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

            Console.Write("Masukkan Nama Type   : ");
            string type_overtime = Console.ReadLine();
            Console.Write("Masukkan Detail Type : ");
            string detail_type = Console.ReadLine();
            Console.Write("Masukkan Amount      : ");
            int amount_overtime = Convert.ToInt32(Console.ReadLine());

            OvertimeType overtimetype = new OvertimeType()
            {
                type = type_overtime,
                detail = detail_type,
                amount = amount_overtime

            };
            try
            {
                _context.OvertimeTypes.Add(overtimetype);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write(e.InnerException);
                Console.Write(e.Message);
                Console.Write(e.StackTrace);
            }
        }

        public List<OvertimeType> GetAll()
        {
            Console.Clear();

            var getAll = _context.OvertimeTypes.ToList();
            foreach (OvertimeType overtimetype in getAll)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id     : " + overtimetype.id);
                Console.WriteLine("Type   : " + overtimetype.type);
                Console.WriteLine("Detail : " + overtimetype.detail);
                Console.WriteLine("Amount : " + overtimetype.amount);
                Console.WriteLine("-------------------------");
            }

            return getAll;
        }


        public OvertimeType getById(int input)
        {
            var overtimetype = _context.OvertimeTypes.Find(input);
            if (overtimetype == null)
            {
                Console.WriteLine("Id yang dicari tidak ada");
            }
            else if (overtimetype.id == input)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Id     : " + overtimetype.id);
                Console.WriteLine("Type   : " + overtimetype.type);
                Console.WriteLine("Detail : " + overtimetype.detail);
                Console.WriteLine("Amount : " + overtimetype.amount);
                Console.WriteLine("-------------------------");
            }
            return overtimetype;
        }

        public OvertimeType searchId(int input)
        {
            var overtimetype = _context.OvertimeTypes.Find(input);
            if (overtimetype == null)
            {
                Console.WriteLine("Id yang dicari tidak ada");
            }

            return overtimetype;
        }

        public int Update(int input)
        {
            Console.Write("Masukkan Type Baru   :");
            string new_type = Console.ReadLine();
            Console.Write("Masukkan Detail Baru   :");
            string new_detail = Console.ReadLine();
            Console.Write("Masukkan Amount Baru :");
            int new_amount = Convert.ToInt32(Console.ReadLine());

            var getover = _context.OvertimeTypes.Find(input);
            if (getover == null)
            {
                Console.WriteLine("Id yang dicari tidak ada");
            }
            else
            {
                OvertimeType overtimetype = searchId(input);
                overtimetype.type = new_type;
                overtimetype.detail = new_detail;
                overtimetype.amount = new_amount;

                _context.Entry(overtimetype).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            return input;
        }

        public int Delete(int input)
        {
            OvertimeType overtimetype = _context.OvertimeTypes.Find(input);
            _context.Entry(overtimetype).State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChanges();

            return input;
        }
    }
}

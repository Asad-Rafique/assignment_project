using Azure;

namespace assignment_project.Data
{
    public class GetDataServis
    {





        private readonly DataBaseContext _db;
        public GetDataServis(DataBaseContext db)
        {
            _db = db;
        }

        public List<response>? classesWithMoreThan100Students()
        {
            List<response> reponse = new List<response>();
            try
            {
                reponse = _db.Classes.Where(x => x.Enrolleds.Count > 100).Select(s => new response { outPut1 = s.Name, outPut2 = s.RoomNumber }).ToList();
                return reponse;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        public List<response>? GetIdandMajor()
        {
            List<response> reponse = new List<response>();
            try
            {
                reponse = _db.Students.Where(std => !_db.Enrolleds.Any(enrolled => enrolled.SId == std.SId && _db.Classes.Any(cls => cls.CId == enrolled.CId && _db.Faculties.Any(faculty => faculty.FId == cls.FId && faculty.DeptId == 22)))).Select(x => new response { outPut1 = x.SId.ToString(), outPut2 = x.Major }).ToList();
                return reponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        public List<response>? studentsEnrolledInMoreThanTwoClasses()
        {
            List<response> reponse = new List<response>();
            try
            {
                reponse = _db.Students.Where(s => s.Enrolleds.Count > 2).Select(s => new response { outPut1 = s.SName, outPut2 = s.Enrolleds.Count.ToString() }).ToList();
                return reponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        public List<response>? facultyWithClassCounts()
        {
            List<response> reponse = new List<response>();
            try
            {
                reponse = _db.Faculties.OrderByDescending(f => f.Classes.Count).Select(f => new response { outPut1 = f.FName, outPut2 = f.Classes.Count.ToString() }).ToList();
                return reponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        public List<response>? studentsInComputerScienceClasses()
        {
            List<response> reponse = new List<response>();
            try
            {
                reponse = _db.Students.Where(s => s.Enrolleds.Any(e => _db.Classes.Any(c => c.CId == e.CId && _db.Faculties.Any(f => f.FId == c.FId && f.DeptId == 22)))).Select(s => new response { outPut1 = s.SName }).ToList();
                return reponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }




}


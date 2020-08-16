using AttendanceSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Repository
{
    public class LevelRepo
    {
        public string AddLevel(StudentLevel newLevel)
        {
            try
            {
                using (var context = new BASContext())
                {
                    if (context.Levels.Any(a => a.Level == newLevel.Level && !a.IsDeleted))
                        return "Level already exists";
                    //if (context.Levels.Any(a => a.LevelRank == newLevel.LevelRank && !a.IsDeleted))
                    //    return "A Level already exist for this Level rank";

                    context.Levels.Add(newLevel);
                    if (context.SaveChanges() > 0) return "Level added successfully";
                    return "Level could not be added";

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteLevel(int levelId)
        {
            using (var context = new BASContext())
            {
                if (context.CourseRegistrations.Any(a => a.LevelId == levelId))
                    return "Level cannot be deleted because it is in use";

                var level = context.Levels.SingleOrDefault(a => a.Id == levelId);
                if (level != null)
                {
                    level.IsDeleted = true;
                    if (context.SaveChanges() > 0) return "Level deleted successfully";
                    return "Level could not be deleted";
                }

                return "Level not found";
            }

        }

        public List<StudentLevel> GetAllLevels()
        {
            try
            {
                using (var context = new BASContext())
                {
                    return context.Levels.Where(a => !a.IsDeleted).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StudentLevel GetLevel(int levelId)
        {
            try
            {
                using (var context = new BASContext())
                {
                    return context.Levels.SingleOrDefault(a => a.Id == levelId && !a.IsDeleted);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateLevel(StudentLevel level)
        {
            using (var context = new BASContext())
            {
                var oldLevel = context.Levels.SingleOrDefault(a => a.Id == level.Id && !a.IsDeleted);
                if (oldLevel == null)
                    return "Level not found";

                if (context.Levels.Any(a => a.Level == level.Level && !a.IsDeleted && a.Id != level.Id))
                    return "Level already exist";
                //if (context.Levels.Any(a => a.LevelRank == level.LevelRank && !a.IsDeleted && a.Id != level.Id))
                //    return "Rank already exist for another level";

                oldLevel.Level = level.Level;

                if (context.SaveChanges() > 0) return "Level details updated successfully";
                return "Level details could not be updated";
            }
        }
    }
}

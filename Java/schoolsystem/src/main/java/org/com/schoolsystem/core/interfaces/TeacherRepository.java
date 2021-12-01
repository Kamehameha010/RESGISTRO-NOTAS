package org.com.schoolsystem.core.interfaces;

import java.util.List;

import org.com.schoolsystem.core.entities.Teacher;
import org.com.schoolsystem.core.entities.ViewTeachers;
import org.com.schoolsystem.core.queryFilters.CourseFilter;
import org.springframework.data.repository.CrudRepository;



public interface TeacherRepository extends CrudRepository<Teacher, Integer> {
    List<ViewTeachers> GetTeaches();

    List<Object> GetCoursesbyTeacher(CourseFilter filter);
}
